using Gocent.Abp.Authorization.IToken;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gocent.Abp.Authorization.Token
{
    public class TokenService : ITokenService
    {
        private readonly IMd5Service md5Service;
        private readonly IDESService dESService;

        public TokenService(IMd5Service md5Service,IDESService dESService)
        {
            this.md5Service = md5Service;
            this.dESService = dESService;
        }
        /// <summary>
        /// 创建Token方法
        /// </summary>
        /// <param name="userId">用户名</param>
        /// <param name="expMin">过期时间（按分钟）</param>
        /// <returns></returns>
        public string CreateToken(string userId, int expMin)
        {
            //定义过期时间
            DateTime timeNow = DateTime.Now;
            DateTime timeExp = DateTime.Now.AddMinutes(expMin);
            dynamic mydata = new { userId=userId,time=timeExp };
            string tokenData = JsonConvert.SerializeObject(mydata);
            string token = this.dESService.Encrypt(tokenData);
            //记住，机关或者国企内网中，可能因为浏览器版本问题，无法传输=、+、<、>这样的字符，需要如下代码转义
            //但是转义的代码外后端传输时，必须要Form表单格式才能正常传输
            //由于测试阶段即.NET版本比较新，无法重现这个错误，还请各位同学在实际内网环境下开发时多多留意~
            //var res = token.Replace("+","%2B").Replace("=","%6B");
            var res = token;
            return res;
        }
        /// <summary>
        /// 验证Token方法
        /// </summary>
        /// <param name="token">token的字符串</param>
        /// <returns></returns>
        public (string userId, bool isDateTimeExp) DecryptToken(string token)
        {
            string decrypto = this.dESService.Decrypt(token);
          
            if (decrypto != null)
            {
                dynamic resdata = JsonConvert.DeserializeObject<dynamic>(decrypto);
                DateTime dateexp = Convert.ToDateTime(resdata.time);
                bool isTimeExp = false;
                if (dateexp<DateTime.Now)
                {
                    isTimeExp = true;
                }
                return ((string)resdata.userId, isTimeExp);
            }
            else
            {
                return ("0", true);
            }
        }
    }
}
