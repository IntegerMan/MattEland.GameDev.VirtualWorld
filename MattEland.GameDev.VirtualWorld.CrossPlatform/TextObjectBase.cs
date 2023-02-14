namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

/// <summary>
/// A displayable object that is drawn as text to the screen using SpriteFonts
/// </summary>
/// <remarks>
/// Code based on that in Game Development by MonoGame. See https://github.com/Apress/game-dev-monogame
/// </remarks>
public abstract class TextObjectBase : BaseGameObject
{
    private readonly SpriteFont _font;

    protected TextObjectBase(SpriteFont font) : base(null)
    {
        _font = font;
    }

    public string Text { get; set; }

    public override void Render(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(_font, Text, _position, Color.White);
    }
}