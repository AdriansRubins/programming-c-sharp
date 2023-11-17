namespace design_pattern_petrol_card.TankStation;

public interface IEncryptionStrategy
{
    byte[] encrypt();
    string decrypt();
}