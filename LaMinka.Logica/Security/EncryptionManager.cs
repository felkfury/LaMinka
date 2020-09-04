using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Security.Encryption
{
    public class EncryptionManager
    {
        private string password;

        #region Constructor

        private EncryptionManager()
        {

        }

        public EncryptionManager(string password)
            : this()
        {
            this.password = password;
        }

        #endregion

        #region Methods

        public string Encrypt(string messageToEncrypt)
        {
            byte[] buffer;
            UTF8Encoding utf8 = new UTF8Encoding();
            messageToEncrypt = (messageToEncrypt ?? String.Empty);
            //Step 1. We hash the password using MD5
            //We use the MD5 hash generator as the result is a 128 bit byte array
            //which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(password));

            TripleDESCryptoServiceProvider tdesAlgorithm = new TripleDESCryptoServiceProvider();

            //Step 2. Setup the encoder
            tdesAlgorithm.Key = tdesKey;
            tdesAlgorithm.Mode = CipherMode.ECB;
            tdesAlgorithm.Padding = PaddingMode.PKCS7;

            //Step 3. Convert the input string to a byte[]
            byte[] dataToEncrypt = utf8.GetBytes(messageToEncrypt);

            //Step 4. Attempt to encrypt the string
            try
            {
                ICryptoTransform encryptor = tdesAlgorithm.CreateEncryptor();
                buffer = encryptor.TransformFinalBlock(dataToEncrypt, 0, dataToEncrypt.Length);
            }
            finally
            {
                //Clear the TripleDes and Hashprovider services of any sensitive information
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }

            //Step 5. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(buffer);
        }

        public string Decrypt(string messageToDecrypt)
        {
            byte[] buffer;
            UTF8Encoding utf8 = new UTF8Encoding();

            //Step 1. We hash the passphrase using MD5
            //We use the MD5 hash generator as the result is a 128 bit byte array
            //which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(password));

            TripleDESCryptoServiceProvider tdesAlgorithm = new TripleDESCryptoServiceProvider();

            //Step 2. Setup the decoder
            tdesAlgorithm.Key = tdesKey;
            tdesAlgorithm.Mode = CipherMode.ECB;
            tdesAlgorithm.Padding = PaddingMode.PKCS7;

            //Step 3. Convert the input string to a byte[]
            byte[] dataToDecrypt = Convert.FromBase64String(messageToDecrypt);

            //Step 4. Attempt to decrypt the string
            try
            {
                ICryptoTransform decryptor = tdesAlgorithm.CreateDecryptor();
                buffer = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }
            finally
            {
                //Clear the TripleDes and Hashprovider services of any sensitive information
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }

            //Step 5. Return the decrypted string in UTF8 format
            return utf8.GetString(buffer);
        }

        public string EncryptBase64(string messageToEncrypt)
        {
            return Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(messageToEncrypt));
        }

        public string DecryptBase64(string messageToDecrypt)
        {
            return ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(messageToDecrypt));
        }

        #endregion
    }
}
