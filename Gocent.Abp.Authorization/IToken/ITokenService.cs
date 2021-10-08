using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gocent.Abp.Authorization.IToken
{
   public interface ITokenService
    {
        /// <summary>
        /// 创建Token方法
        /// </summary>
        /// <param name="userId">用户名</param>
        /// <param name="expMin">过期时间（按分钟）</param>
        /// <returns></returns>
        public string CreateToken(string userId, int expMin);
        /// <summary>
        /// 验证Token方法
        /// </summary>
        /// <param name="token">token的字符串</param>
        /// <returns></returns>
        public (string userId, bool isDateTimeExp) DecryptToken(string token);
    }
}
