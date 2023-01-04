namespace Players.Server;
public class Player : Person
{
    public decimal Weight { get; set; }
    public int CurrentNumber { get; set; }

    public Foot Foot { get; set; }
    public Position Position { get; set; }
}

public enum Foot
{
    Right = 1,
    Left,
    Both
}

public enum Position
{
    GK = 1,
    CB,
    CF
}