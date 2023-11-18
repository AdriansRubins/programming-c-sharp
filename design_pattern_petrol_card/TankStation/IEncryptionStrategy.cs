namespace design_pattern_petrol_card.TankStation;

public interface IEncryptionStrategy
{
    byte[] Encrypt(int pin);
    int Decrypt(byte[] cipherText);
}