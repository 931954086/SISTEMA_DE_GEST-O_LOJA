using System;
using System.Security.Cryptography;
using System.Text;

namespace SISTEMA_DE_GESTÃO_LOJA.Criptografia
{
    public class Cryptography

    {
        private RijndaelManaged rijndael = new RijndaelManaged();
        private byte[] passBytes;
        private byte[] encryptionkeyBytes;

        /// <summary>
        /// Construtor da classe Cryptography. É obrigatório informar a chave de criptografia como parâmetro
        /// </summary>
        /// <param name="encryptionKey"></param>
        public Cryptography(string encryptionKey)
        {
            passBytes = Encoding.UTF8.GetBytes(encryptionKey);
        }

        /// <summary>
        /// Método que criptografa o texto passado como parâmetro
        /// </summary>
        /// <param name="textToEncrypt"></param>
        /// <returns>Uma string criptografada</returns>
        public string Encrypt(string textToEncrypt)
        {
            SetOperation();

            SetBeginCryptography();

            byte[] textDataByte = Encoding.UTF8.GetBytes(textToEncrypt);

            ICryptoTransform objtransform = rijndael.CreateEncryptor();
            return Convert.ToBase64String(objtransform.TransformFinalBlock(textDataByte, 0, textDataByte.Length));
        }

        /// <summary>
        /// Método que descriptografa o texto criptografado
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns>Uma string descriptografada</returns>
        public string Decrypt(string encryptedText)
        {
            SetOperation();

            byte[] encryptedTextByte = Convert.FromBase64String(encryptedText);
            encryptionkeyBytes = new byte[0x10];

            SetBeginCryptography();

            byte[] textByte = rijndael.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
            return Encoding.UTF8.GetString(textByte);
        }

        private void SetOperation()
        {
            rijndael.Mode = CipherMode.CBC;
            rijndael.Padding = PaddingMode.PKCS7;
            rijndael.KeySize = 0x80;
            rijndael.BlockSize = 0x80;
        }

        private void SetBeginCryptography()
        {
            encryptionkeyBytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            int len = passBytes.Length;
            if (len > encryptionkeyBytes.Length)
            {
                len = encryptionkeyBytes.Length;
            }

            Array.Copy(passBytes, encryptionkeyBytes, len);

            rijndael.Key = encryptionkeyBytes;
            rijndael.IV = encryptionkeyBytes;
        }
    }
}
