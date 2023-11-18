namespace design_pattern_petrol_card.Card;

public class Gold : ICardStatus
{
    public void Promote(Card card)
    {
        Console.WriteLine("Already Gold");
    }

    public int CalculatePoints(int amountOfLiter)
    {
        var points = amountOfLiter;
        points += (amountOfLiter / 25) * 8;

        return points;
    }
}