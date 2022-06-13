using System;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
namespace AES_final
{
    class Aes
    {
        public static string IV = "qo1lc3sjd8zpt9cx";  // 16 chars = 128 bytes

        //Sifravimo bloko parametrai
        public static string Encrypt(string decrypted,string Key)
        {
            
                byte[] textbytes = ASCIIEncoding.ASCII.GetBytes(decrypted);
                AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();
                encdec.BlockSize = 128;
                encdec.KeySize = 256;
                encdec.Key = ASCIIEncoding.ASCII.GetBytes(Key);
                encdec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
                encdec.Padding = PaddingMode.PKCS7;
                encdec.Mode = CipherMode.CBC;

                ICryptoTransform icrypt = encdec.CreateEncryptor(encdec.Key, encdec.IV);
                

                byte[] enc = icrypt.TransformFinalBlock(textbytes, 0, textbytes.Length);
                icrypt.Dispose();

                return Convert.ToBase64String(enc);           
        }

        //Desifravimo bloko parametrai
        public static string Decrypt(string encrypted,string Key)
        {
            byte[] encbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider encdec = new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 256,
                Key = ASCIIEncoding.ASCII.GetBytes(Key),
                IV = ASCIIEncoding.ASCII.GetBytes(IV),
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CBC
            };

            ICryptoTransform icrypt = encdec.CreateDecryptor(encdec.Key, encdec.IV);

            byte[] dec = icrypt.TransformFinalBlock(encbytes, 0, encbytes.Length);
            icrypt.Dispose();

            return ASCIIEncoding.ASCII.GetString(dec);
        }
    }
}
