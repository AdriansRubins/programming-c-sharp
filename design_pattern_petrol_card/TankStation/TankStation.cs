using System.Security.Authentication;

namespace design_pattern_petrol_card.TankStation;

public class TankStation
{
    public void UseCard(Card.Card card, IEncryptionStrategy encryptionStrategy, int pin, int amountOfLiter)
    {
        if (pin == encryptionStrategy.Decrypt(card.Pin))
        {
            card.AddPetrol(amountOfLiter);
        }
        else
        {
            throw new AuthenticationException("Wrong pin");
        }
    }
}