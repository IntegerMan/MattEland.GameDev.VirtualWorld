namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

/// <summary>
/// A line segment
/// </summary>
/// <remarks>
/// Code based on that in Game Development by MonoGame. See https://github.com/Apress/game-dev-monogame
/// </remarks>

public class Segment
{
    public Vector2 P1 { get; }
    public Vector2 P2 { get; }

    public Segment(Vector2 p1, Vector2 p2)
    {
        P1 = p1;
        P2 = p2;
    }
}