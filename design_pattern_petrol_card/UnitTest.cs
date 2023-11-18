using System.Security.Authentication;
using design_pattern_petrol_card.Card;
using design_pattern_petrol_card.TankStation;

namespace design_pattern_petrol_card;

public class UnitTest
{
    private TankStation.TankStation? _tankStation;
    private Card.Card? _card;

    [SetUp]
    public void Setup()
    {
        _tankStation = new TankStation.TankStation();
        _card = new Card.Card(1234, new AES());
    }

    [Test]
    public void TestBalance()
    {
        _tankStation!.UseCard(_card!, new AES(), 1234, 10);
        Assert.That(_card!.Balance, Is.EqualTo(10));
        _tankStation!.UseCard(_card!, new AES(), 1234, 500);
        Assert.That(_card!.Balance, Is.EqualTo(510));
        _tankStation!.UseCard(_card!, new AES(), 1234, 500);
        Assert.That(_card!.Balance, Is.EqualTo(1070));
    }

    [Test]
    public void TestStatus()
    {
        _tankStation!.UseCard(_card!, new AES(), 1234, 10);
        Assert.That(_card!.CardStatus.GetType().Name, Is.EqualTo(new Blue().GetType().Name));
        _tankStation!.UseCard(_card!, new AES(), 1234, 500);
        Assert.That(_card!.CardStatus.GetType().Name, Is.EqualTo(new Bronze().GetType().Name));
    }

    [Test]
    public void TestEncryption()
    {
        var encryptedPin = new AES().Encrypt(1234);
        _tankStation!.UseCard(_card!, new AES(), 1234, 10);
        Assert.That(_card!.Pin, Is.EqualTo(encryptedPin));
    }

    [Test]
    public void TestFalsePin()
    {
        Assert.Throws<AuthenticationException>(() => _tankStation!.UseCard(_card!, new AES(), 3214, 10));
    }

    [Test]
    public void TestFalseEncryption()
    {
        Assert.Throws<AuthenticationException>(() => _tankStation!.UseCard(_card!, new AES(), 3214, 10));
    }
}