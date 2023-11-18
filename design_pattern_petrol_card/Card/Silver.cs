namespace design_pattern_petrol_card.Card;

public class Silver : ICardStatus
{
    public void Promote(Card card)
    {
        if (card.Balance >= 5000)
        {
            card.CardStatus = new Gold();
        }
        else
        {
            Console.WriteLine("Not enough points to promote");
        }
    }

    public int CalculatePoints(int amountOfLiter)
    {
        var points = amountOfLiter;
        points += (amountOfLiter / 25) * 5;

        return points;
    }
}