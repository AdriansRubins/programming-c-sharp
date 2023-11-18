using System.Security.Cryptography;

namespace design_pattern_petrol_card.TankStation;

public class AES : IEncryptionStrategy
{
    public byte[] Encrypt(int pin)
    {
        var plainText = pin.ToString();

        if (plainText is not { Length: > 0 })
            throw new ArgumentNullException("plainText");
        if (Configuration.Key is not { Length: > 0 })
            throw new ArgumentNullException("Configuration.Key");
        if (Configuration.IV is not { Length: > 0 })
            throw new ArgumentNullException("IV");

        byte[] encrypted;

        using var aesAlg = Aes.Create();
        aesAlg.Key = Configuration.Key;
        aesAlg.IV = Configuration.IV;

        var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

        using var msEncrypt = new MemoryStream();
        using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
        using (var swEncrypt = new StreamWriter(csEncrypt))
        {
            swEncrypt.Write(plainText);
        }

        encrypted = msEncrypt.ToArray();

        return encrypted;
    }


    public int Decrypt(byte[] cipherText)
    {
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException("cipherText");
        if (Configuration.Key == null || Configuration.Key.Length <= 0)
            throw new ArgumentNullException("Configuration.Key");
        if (Configuration.IV == null || Configuration.IV.Length <= 0)
            throw new ArgumentNullException("IV");

        string plaintext;

        using var aesAlg = Aes.Create();
        aesAlg.Key = Configuration.Key;
        aesAlg.IV = Configuration.IV;

        var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

        using var msDecrypt = new MemoryStream(cipherText);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        using var srDecrypt = new StreamReader(csDecrypt);
        plaintext = srDecrypt.ReadToEnd();

        return int.Parse(plaintext);
    }
}