using design_pattern_petrol_card.TankStation;

namespace design_pattern_petrol_card.Card;

public class Card
{
    public byte[] Pin { get; }
    public int Balance { get; private set; }
    public ICardStatus CardStatus { get; set; }

    public Card(int pin, IEncryptionStrategy encryptionStrategy)
    {
        Pin = encryptionStrategy.Encrypt(pin);
        CardStatus = new Blue();
    }

    public void AddPetrol(int amountOfLiter)
    {
        Balance += CardStatus.CalculatePoints(amountOfLiter);
        CardStatus.Promote(this);
    }
}