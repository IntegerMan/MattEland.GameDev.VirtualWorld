namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

public abstract class WorldObjectBase
{
    public WorldObjectBase(float x, float y) : this(new Vector2(x, y))
    {
    }

    public WorldObjectBase(Vector2 pos)
    {
        Position = pos;
    }

    public Vector2 Position { get; }

    public Vector2 ToScreenPos(int tileSize) 
        => new Vector2(Position.X * tileSize, Position.Y * tileSize);
}