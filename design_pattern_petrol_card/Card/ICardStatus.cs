using System.Transactions;

namespace design_pattern_petrol_card.Card;

public interface ICardStatus
{
    void Promote(Card card);
    int CalculatePoints(int amountOfLiter);
}