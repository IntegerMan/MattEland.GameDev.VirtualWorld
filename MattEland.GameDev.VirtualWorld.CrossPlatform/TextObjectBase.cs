namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

/// <summary>
/// A displayable object that is drawn as text to the screen using SpriteFonts
/// </summary>
/// <remarks>
/// Code based on that in Game Development by MonoGame. See https://github.com/Apress/game-dev-monogame
/// </remarks>
public abstract class TextObjectBase : WorldObjectBase
{
    private readonly SpriteFont _font;

    protected TextObjectBase(SpriteFont font)
    {
        _font = font;
    }

    protected TextObjectBase(SpriteFont font, Vector2 position) : base(position)
    {
        _font = font;
    }

    public string? Text { get; set; }

    public override void Render(GameContext context)
    {
        context.Sprites!.DrawString(_font, Text, Position, Color.White);
    }
}