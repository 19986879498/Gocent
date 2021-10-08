using Gocent.Abp.Authorization.IToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gocent.Abp.Authorization.Token
{
    public class Md5Service : IMd5Service
    {
        /// <summary>
        /// 转换md5方法
        /// </summary>
        /// <param name="str">需要转换的字段</param>
        /// <returns></returns>
        public string ToMd5Ace(string str)
        {
            //创建Md5对象
            MD5 md5obj = new MD5CryptoServiceProvider();
            //得到加密后的byte数组
            byte[] md5byte = md5obj.ComputeHash(Encoding.Default.GetBytes(str + "Gocent"));
            //获取加密后的字符串
            string Md5Result = BitConverter.ToString(md5byte).Replace("-", "");
            return Md5Result;
        }
    }
}
