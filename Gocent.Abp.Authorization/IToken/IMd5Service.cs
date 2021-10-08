using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gocent.Abp.Authorization.IToken
{
   public interface IMd5Service
    {
        /// <summary>
        /// 转换md5方法
        /// </summary>
        /// <param name="str">需要转换的字段</param>
        /// <returns></returns>
        public string ToMd5Ace( string str);
    }
}
