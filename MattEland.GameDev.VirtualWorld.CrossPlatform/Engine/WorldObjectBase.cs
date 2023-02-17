namespace MattEland.GameDev.VirtualWorld.CrossPlatform.Engine;

/// <summary>
/// The base game object
/// </summary>
public abstract class WorldObjectBase
{
    protected WorldObjectBase() : this(0, 0)
    {

    }

    protected WorldObjectBase(float x, float y) : this(new Vector2(x, y))
    {
    }

    protected WorldObjectBase(Vector2 pos)
    {
        Position = pos;
    }

    public virtual void Update(GameContext context)
    {

    }

    public Vector2 Position { get; set; }
    public virtual bool IsImpassible => false;

    public Vector2 ToScreenPos(int tileSize)
        => new(Position.X * tileSize, Position.Y * tileSize);

    public abstract void Render(GameContext context);
}