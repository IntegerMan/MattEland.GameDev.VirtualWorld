namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

public class GameContext
{
    /// <summary>
    /// The SpriteBatch used to render to the screen
    /// </summary>
    public SpriteBatch? Sprites { get; internal set; }

    /// <summary>
    /// The amount of time in fractional seconds that has passed since the last update or render
    /// </summary>
    public float DeltaTime { get; private set; }

    /// <summary>
    /// Updates the internal context values for the new frame
    /// </summary>
    /// <param name="gameTime">A GameTime instance indicating the amount of time elapsed since last update</param>
    public void Update(GameTime gameTime)
    {
        DeltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;
        IsSlow = gameTime.IsRunningSlowly;
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
    public GraphicsDevice Graphics { get; internal set; }
}