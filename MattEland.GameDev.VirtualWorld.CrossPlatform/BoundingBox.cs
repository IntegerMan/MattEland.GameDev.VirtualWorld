namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

/// <summary>
/// Represents a collision box
/// </summary>
/// <remarks>
/// Code based on that in Game Development by MonoGame. See https://github.com/Apress/game-dev-monogame
/// </remarks>

public class BoundingBox
{
    public Vector2 Position { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }

    public Rectangle Rectangle => new((int)Position.X, (int)Position.Y, (int)Width, (int)Height);

    public BoundingBox(Vector2 position, float width, float height)
    {
        Position = position;
        Width = width;
        Height = height;
    }

    public bool CollidesWith(BoundingBox otherBB)
    {
        return Position.X < otherBB.Position.X + otherBB.Width &&
               Position.X + Width > otherBB.Position.X &&
               Position.Y < otherBB.Position.Y + otherBB.Height &&
               Position.Y + Height > otherBB.Position.Y;
    }

    public bool CollidesWith(Segment segment)
    {
        return CollidesWith(segment.P1) || CollidesWith(segment.P2);
    }

    public bool CollidesWith(Vector2 p)
    {
        return p.X < Position.X + Width &&
               p.X > Position.X &&
               p.Y < Position.Y + Height &&
               p.Y > Position.Y;
    }
}