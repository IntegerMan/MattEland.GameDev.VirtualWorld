namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

public class Actor : WorldObjectBase
{
    private readonly Texture2D _texture;
    private readonly Rectangle _sourceRect;

    public Actor(float x, float y, Texture2D texture, Rectangle sourceRect) : base(x, y)
    {
        _texture = texture;
        _sourceRect = sourceRect;
    }

    public override void Render(SpriteBatch spriteBatch)
    {
        Vector2 screenPos = ToScreenPos(VirtualWorldGame.ScreenTileSize);

        Rectangle targetRect = new((int)screenPos.X, (int)screenPos.Y, VirtualWorldGame.ScreenTileSize, VirtualWorldGame.ScreenTileSize);

        spriteBatch.Draw(_texture, targetRect, _sourceRect, Color.White);
    }
}
