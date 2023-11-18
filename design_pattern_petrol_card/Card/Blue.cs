namespace design_pattern_petrol_card.Card;

public class Blue : ICardStatus
{
    public void Promote(Card card)
    {
        if (card.Balance >= 500)
        {
            card.CardStatus = new Bronze();
        }
        else
        {
            Console.WriteLine("Not enough points to promote");
        }
    }

    public int CalculatePoints(int amountOfLiter)
    {
        return amountOfLiter;
    }
}