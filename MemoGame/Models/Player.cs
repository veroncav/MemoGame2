namespace MemoGame.Models;

public class Player
{
    public string Name { get; set; } = string.Empty;
    public int Score { get; set; } = 0;

    public Player(string name)
    {
        Name = name;
    }
}
