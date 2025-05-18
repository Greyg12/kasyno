using Xunit;

public class PlayerTests
{
    [Fact]
    public void AddBalance_IncreasesBalance()
    {
        // Arrange
        var player = new Player("Test", 100);

        // Act
        player.AddBalance(50);

        // Assert
        Assert.Equal(150, player.Balance);
    }

    [Fact]
    public void SubtractBalance_DecreasesBalance_WhenEnoughFunds()
    {
        var player = new Player("Test", 100);

        var result = player.SubtractBalance(40);

        Assert.True(result);
        Assert.Equal(60, player.Balance);
    }

    [Fact]
    public void SubtractBalance_DoesNotDecreaseBalance_WhenNotEnoughFunds()
    {
        var player = new Player("Test", 30);

        var result = player.SubtractBalance(50);

        Assert.False(result);
        Assert.Equal(30, player.Balance);
    }
}
