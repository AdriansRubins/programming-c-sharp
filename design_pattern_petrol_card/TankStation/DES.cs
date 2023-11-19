using System.Security.Cryptography;

namespace design_pattern_petrol_card.TankStation;

public class DES : IEncryptionStrategy
{
    [Obsolete("Obsolete")]
    public byte[] Encrypt(int plainText)
    {
        byte[] encrypted;

        using var des = new DESCryptoServiceProvider();
        des.Key = new byte[8] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };;
        des.IV = new byte[8] { 0x01, 0x03, 0x02, 0x04, 0x05, 0x06, 0x07, 0x08 };;

        var encryptor = des.CreateEncryptor(des.Key, des.IV);

        using var msEncrypt = new MemoryStream();
        using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
        using (var swEncrypt = new StreamWriter(csEncrypt))
        {
            swEncrypt.Write(plainText);
        }

        encrypted = msEncrypt.ToArray();

        return encrypted;
    }

    [Obsolete("Obsolete")]
    public int Decrypt(byte[] cipherText)
    {
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException(nameof(cipherText));

        string plaintext;

        using var des = new DESCryptoServiceProvider();
        des.Key = new byte[8] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08 };;
        des.IV = new byte[8] { 0x01, 0x03, 0x02, 0x04, 0x05, 0x06, 0x07, 0x08 };;

        var decryptor = des.CreateDecryptor(des.Key, des.IV);

        using var msDecrypt = new MemoryStream();
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write);
        using (var srDecrypt = new StreamReader(csDecrypt))
        {
            plaintext = srDecrypt.ReadToEnd();
        }

        return int.Parse(plaintext);
    }
}