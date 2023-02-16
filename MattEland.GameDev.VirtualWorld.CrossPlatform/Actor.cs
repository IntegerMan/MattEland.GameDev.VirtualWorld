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

    public float Speed { get; set; } = 5.0f;

    public override void Update(GameContext context)
    {
        float maxMove = context.DeltaTime * Speed;

        // TODO: Using this algorithm, diagonal movement is faster than pure horizontal or vertical
        // a better algorithm would have a max speed and rotate it using trigonometry on an angle as a vector
        Position = Position.Offset(context.Random.NextSingle(-maxMove, maxMove),
                                   context.Random.NextSingle(-maxMove, maxMove));

        // TODO: I need to check for collision as well!
    }

    public override void Render(GameContext context)
    {
        Vector2 screenPos = ToScreenPos(VirtualWorldGame.ScreenTileSize);

        Rectangle targetRect = new((int)screenPos.X, (int)screenPos.Y, VirtualWorldGame.ScreenTileSize, VirtualWorldGame.ScreenTileSize);

        context.Sprites.Draw(_texture, targetRect, _sourceRect, Color.White);
    }
}
