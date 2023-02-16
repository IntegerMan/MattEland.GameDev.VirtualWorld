namespace MattEland.GameDev.VirtualWorld.CrossPlatform.Engine;

public class GameContext
{
    private Keys[] _lastPressedKeys = {};
    private Keys[] _pressedKeys = {};

    public GameContext(SpriteBatch sprites, GraphicsDevice graphics)
    {
        Sprites = sprites;
        Graphics = graphics;
    }

    /// <summary>
    /// The SpriteBatch used to render to the screen
    /// </summary>
    public SpriteBatch Sprites { get; }

    /// <summary>
    /// The amount of time in fractional seconds that has passed since the last update or render
    /// </summary>
    public float DeltaTime { get; private set; }

    /// <summary>
    /// Updates the internal context values for the new frame
    /// </summary>
    /// <param name="gameTime">A GameTime instance indicating the amount of time elapsed since last update</param>
    /// <param name="isRender">True if this is the update that occurs during Draw, false if this is the standard update</param>
    public void Update(GameTime gameTime, bool isRender)
    {
        DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        IsSlow = gameTime.IsRunningSlowly;

        if (!isRender)
        {
            _lastPressedKeys = _pressedKeys;
            _pressedKeys = Keyboard.GetState().GetPressedKeys();
        }
    }

    /// <summary>
    /// Gets a value indicating whether or not the rendering engine is struggling to keep up
    /// </summary>
    public bool IsSlow { get; private set; }

    /// <summary>
    /// The shared randomizer used by all game objects
    /// </summary>
    public Random Random { get; } = new();

    /// <summary>
    /// Gets the GraphicsDevice used to work with the screen
    /// </summary>
    public GraphicsDevice Graphics { get; }

    public bool IsKeyPressed(Keys key)
    {
        // TODO: This works, but this is tiring. It'd be a lot nicer if we allowed holding keys on an interval

        // This will only be true if the key is NEWLY pressed
        return _pressedKeys.Contains(key) && !_lastPressedKeys.Contains(key);
    }
}