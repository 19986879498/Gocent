using Gocent.Abp.Authorization.IToken;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Gocent.Abp.Authorization.Token
{
    public class DESService : IDESService
    {
        private byte[] Key = null;
        private byte[] IV = null;

        public DESService(IConfiguration configuration)
        {
            this.Key = ASCIIEncoding.ASCII.GetBytes(configuration["Token:Key"].ToString());
            this.IV = ASCIIEncoding.ASCII.GetBytes(configuration["Token:IV"].ToString());
        }
        /// <summary>
        /// 解密方法
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string Decrypt(string encryptText)
        {
            string CryptoStr = encryptText;
            //创建des对象
            DESCryptoServiceProvider dESCryptoService = new();
            //将加密字符串转换成byte数组
            byte[] crybyte = Convert.FromBase64String(CryptoStr);
            //创建内存流，用于写入数据
            MemoryStream memoryStream = new();
            //创建加密流
            CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoService.CreateDecryptor(Key, IV), CryptoStreamMode.Write);
            //从buffer的第0个字节到结尾的所有字节写入memoryStream
            cryptoStream.Write(crybyte, 0, crybyte.Length);
            //释放加密流
            cryptoStream.FlushFinalBlock();
            cryptoStream.Close();
            //从memoryStream中获取结果，并转换成Utf8的字符串
            string Result = Encoding.UTF8.GetString(memoryStream.ToArray(), 0, memoryStream.ToArray().Length);
            return Result;
        }
        /// <summary>
        /// 加密方法
        /// </summary>
        /// <param name="encryptText"></param>
        /// <returns></returns>
        public string Encrypt(string text)
        {
            //创建一个DESCryptoServiceProvider对象
            DESCryptoServiceProvider dESCrypto = new();
            //创建一个流
            using MemoryStream memoryStream = new();
            //通过加密流这个类往内存中写入加密信息
            CryptoStream cryptoStream = new(memoryStream, dESCrypto.CreateEncryptor(Key, IV), CryptoStreamMode.Write);
            //将要加密的字符转换成byte数组
            byte[] toEncrypt = new UTF8Encoding().GetBytes(text);
            // 将字节写到转换流里面去。
            cryptoStream.Write(toEncrypt, 0, toEncrypt.Length);
            cryptoStream.FlushFinalBlock();
            // 在调用转换流的FlushFinalBlock方法后，内部就会进行转换了,此时mStream就是加密后的流了。
            byte[] ret = memoryStream.ToArray();
            // Close the streams.
            cryptoStream.Close();
            memoryStream.Close();
            //最后从内存流中拿出加密好的内容并转换成字符串
            string cryptoStr = Convert.ToBase64String(ret);
            return cryptoStr;
        }
    }
}
