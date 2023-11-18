namespace design_pattern_petrol_card.Card;

public class Bronze : ICardStatus
{
    public void Promote(Card card)
    {
        if (card.Balance >= 1250)
        {
            card.CardStatus = new Silver();
        }
        else
        {
            Console.WriteLine("Not enough points to promote");
        }
    }

    public int CalculatePoints(int amountOfLiter)
    {
        var points = amountOfLiter;
        points += (amountOfLiter / 25) * 3;

        return points;
    }
}