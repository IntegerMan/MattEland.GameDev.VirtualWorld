namespace MattEland.GameDev.VirtualWorld.CrossPlatform;


public class TileInfo : WorldObjectBase
{
    public TileInfo(TileType tileType) : this(0,0, tileType)
    {
    }
    public TileInfo(float x, float y, TileType tileType) : this(new Vector2(x, y), tileType)
    {
    }
    public TileInfo(Vector2 pos, TileType tileType) : base(pos)
    {
        TileType = tileType;
    }

    public TileType TileType { get; }
}
