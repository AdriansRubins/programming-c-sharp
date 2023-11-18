using System.Security.Cryptography;

namespace design_pattern_petrol_card.TankStation;

public class DES : IEncryptionStrategy
{
    [Obsolete("Obsolete")]
    public byte[] Encrypt(int plainText)
    {
        byte[] encrypted;

        using var des = new DESCryptoServiceProvider();
        des.Key = Configuration.Key;
        des.IV = Configuration.IV;

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
        if (Configuration.Key == null || Configuration.Key.Length <= 0)
            throw new ArgumentNullException(nameof(Configuration.Key));
        if (Configuration.IV == null || Configuration.IV.Length <= 0)
            throw new ArgumentNullException(nameof(Configuration.IV));

        string plaintext;

        using var des = new DESCryptoServiceProvider();
        des.Key = Configuration.Key;
        des.IV = Configuration.IV;

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