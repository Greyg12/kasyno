using Xunit;

public class CasinoTests
{
    [Fact]
    public void AddPlayer_AddsPlayerToList()
    {
        var casino = new Casino();
        var player = new Player("Test", 100);

        casino.AddPlayer(player);

        Assert.Contains(player, casino.Players);
    }
}
