using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WCMS_COMMON.EncriptionDecription
{
    class WCMSEncription
    {

        #region Member
        private byte[] key = { };
        private byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xab, 0xcd, 0xef };
        private string[] GenerateKey ={"HNJLXWCMS" ,"WCMSFWEKF" ,"YD9CNWCMS","WCMSKN6YR","VNYUCWCMS","WCMSXQKUY","ENZBEWCMS","WCMS2YFHP","RFCE3WCMS","WCMSS3IQ8","YIJ0EDBZ","WCMSNDZEF","4JRNHWCMS","WCMSOXZDT","JZALGWCMS","WCMSSAKZT","M4Z2KWCMS","WCMSFIYII","SPUWAWCMS","WCMSOSSUC", 
                       "LPPEIWCMS" ,"WCMSS3M1N","6GO1KWCMS","WCMSCMWWZ", "3UCYJWCMS"};
        private WCMSEncryptDecryptKey oDbzEncryptDecryptKey = new WCMSEncryptDecryptKey();
        #endregion


        public string Decrypt(string stringToDecrypt)
        {

            try
            {
                string sEncryptionKey = GenerateKey[int.Parse(stringToDecrypt.Substring(stringToDecrypt.Length - 2, 2))];

                stringToDecrypt = stringToDecrypt.Remove(stringToDecrypt.Length - 2, 2);
                byte[] inputByteArray = new byte[stringToDecrypt.Length + 1];

                key = System.Text.Encoding.UTF8.GetBytes(sEncryptionKey);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(stringToDecrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms,
                  des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string Encrypt(string stringToEncrypt)
        {
            try
            {
                oDbzEncryptDecryptKey = GetEncryptKey();

                key = System.Text.Encoding.UTF8.GetBytes(oDbzEncryptDecryptKey.KeyValue);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms,
                  des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray()) + oDbzEncryptDecryptKey.KeyIndex.ToString("00");
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private WCMSEncryptDecryptKey GetEncryptKey()
        {
            WCMSEncryptDecryptKey okey = new WCMSEncryptDecryptKey();
            string EncKey = "";
            Random random = new Random();

            int i = random.Next(25);

            EncKey = GenerateKey[i];

            okey.KeyIndex = i;
            okey.KeyValue = EncKey;


            return okey;
        }


    }
}
