using Xunit;

public class LottoTests
{
    [Fact]
    public void Lotto_CanBeCreated()
    {
        var lotto = new Lotto();
        Assert.Equal("Lotto", lotto.Name);
    }

    [Fact]
    public void Lotto_IsGame()
    {
        var lotto = new Lotto();
        Assert.IsAssignableFrom<Game>(lotto);
    }

    [Fact]
    public void Play_InvalidBet_DoesNotChangeBalance()
    {
        var lotto = new Lotto();
        var player = new Player("Test", 100);

        var originalIn = Console.In;
        try
        {
            using (var input = new System.IO.StringReader("abc\n"))
            {
                Console.SetIn(input);
                lotto.Play(player);
            }
        }
        finally
        {
            Console.SetIn(originalIn);
        }

        Assert.Equal(100, player.Balance);
    }
}
