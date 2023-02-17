namespace MattEland.GameDev.VirtualWorld.CrossPlatform.Engine;

/// <summary>
/// The GameContext object is a context passed to various components during rendering and update.
/// This should contain enough information about the rendering pipeline and the overall game in order
/// for components to make informed decisions and act on the game world.
/// </summary>
public sealed class GameContext
{
    /// <summary>
    /// This governs how long a key must be held in order to repeat as a keypress.
    /// This should be long enough that it doesn't trigger accidentally, but not too long to be annoying
    /// </summary>
    public const float KeyRepeatDelayInSeconds = 0.4f;

    /// <summary>
    /// Tracks the keys currently pressed
    /// </summary>
    private Keys[] _pressedKeys = {};

    /// <summary>
    /// Tracks the delay for repeating a keypress
    /// </summary>
    private readonly Dictionary<Keys, float> _keyDelays = new();

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
            _pressedKeys = Keyboard.GetState().GetPressedKeys();
        }

        DecreaseKeyHoldDelays();
    }

    private void DecreaseKeyHoldDelays()
    {
        // Loop over all keys currently on cooldown and either decrease the cooldown or mark them ready
        foreach (Keys key in _keyDelays.Keys.ToList())
        {
            if (_keyDelays[key] <= DeltaTime)
            {
                // The key has been held a sufficient amount of time to repeat, remove it from the dictionary
                _keyDelays.Remove(key);
            }
            else
            {
                // Key still has an active cooldown, decrease the remaining time
                _keyDelays[key] -= DeltaTime;
            }
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

    /// <summary>
    /// Determines whether or not a key is currently pressed.
    /// Keys are considered pressed if they were not down in the last frame and are down now, OR
    /// they have been held down long enough that <see cref="KeyRepeatDelayInSeconds"/> has elapsed.
    /// </summary>
    /// <param name="key">The key to check if it is pressed</param>
    /// <returns>True if the key is pressed, otherwise false.</returns>
    public bool IsKeyPressed(Keys key)
    {
        if (_pressedKeys.Contains(key) && !_keyDelays.ContainsKey(key))
        {
            _keyDelays[key] = KeyRepeatDelayInSeconds;
            return true;
        }

        return false;
    }
}