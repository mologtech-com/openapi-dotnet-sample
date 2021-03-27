using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MologWMSOpenApi.Internal
{
    public class Util
    {

        public static string EncryptString(string plainText, string appSecretKey)
        {
            // Generate IV
            Random rand = new Random();
            Byte[] ivb = new Byte[16];
            rand.NextBytes(ivb);

            // Generate Cipher Data
            byte[] cipherData;
            Aes aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(appSecretKey);
            aes.IV = ivb;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            ICryptoTransform cipher = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, cipher, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                }
                cipherData = ms.ToArray();
            }

            // Combind IV to CipherData
            return Convert.ToBase64String(aes.IV) + ":" + Convert.ToBase64String(cipherData);
        }
    }
}
