using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gocent.Abp.Authorization.IToken
{
 public   interface IDESService
    {
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Encrypt(string text);
        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="encryptText"></param>
        /// <returns></returns>
        public string Decrypt(string encryptText);

    }
}
