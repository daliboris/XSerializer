using System;
using System.Text;
using XSerializer.Encryption;

namespace XSerializer.Tests.Encryption
{
    public class Base64EncryptionMechanism : IEncryptionMechanism
    {
        public string Encrypt(string plainText)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
        }

        string IEncryptionMechanism.Encrypt(string plainText, object encryptKey, SerializationState serializationState)
        {
            if (serializationState == null) throw new ArgumentNullException(nameof(serializationState));
            return Encrypt(plainText);
        }

        public string Decrypt(string cipherText)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(cipherText));
        }

        string IEncryptionMechanism.Decrypt(string cipherText, object encryptKey, SerializationState serializationState)
        {
            if (serializationState == null) throw new ArgumentNullException(nameof(serializationState));
            return Decrypt(cipherText);
        }
    }
}