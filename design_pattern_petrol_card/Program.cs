// See https://aka.ms/new-console-template for more information

using design_pattern_petrol_card.Card;
using design_pattern_petrol_card.TankStation;

Console.WriteLine("Hello, World!");

var tankStation = new TankStation();
var card = new Card(1234, new AES());
tankStation.UseCard(card, new DES(), 1234, 10);
//tankStation.UseCard(card, new AES(), 3214, 10);
tankStation.UseCard(card, new AES(), 1234, 10);
Console.WriteLine(card.Balance);
Console.WriteLine(card.CardStatus.GetType().Name);
tankStation.UseCard(card, new AES(), 1234, 510);
Console.WriteLine(card.Balance);
Console.WriteLine(card.CardStatus.GetType().Name);