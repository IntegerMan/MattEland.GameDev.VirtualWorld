using MattEland.GameDev.VirtualWorld.CrossPlatform.Engine;
using Microsoft.Xna.Framework.Graphics;

namespace MattEland.GameDev.VirtualWorld.CrossPlatform.Entities;


public class TileInfo : WorldObjectBase
{
    private readonly Texture2D _texture;
    private readonly Rectangle _sourceRect;
    private Rectangle _screenRect;

    public TileInfo(float x, float y, TileType tileType, Texture2D texture, Rectangle sourceRect)
        : base(new Vector2(x, y))
    {
        _texture = texture;
        _sourceRect = sourceRect;
        TileType = tileType;
    }

    public TileType TileType { get; }

    public override bool IsImpassible => TileType == TileType.Wall;

    public override void Update(GameContext context)
    {
        Vector2 screenPos = ToScreenPos(VirtualWorldGame.ScreenTileSize);

        _screenRect = new Rectangle((int)screenPos.X, (int)screenPos.Y, VirtualWorldGame.ScreenTileSize, VirtualWorldGame.ScreenTileSize);
    }

    public override void Render(GameContext context)
    {
        context.Sprites!.Draw(_texture, _screenRect, _sourceRect, Color.White);
    }
}
