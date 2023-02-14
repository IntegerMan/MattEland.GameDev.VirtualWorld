namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

/// <summary>
/// A displayable object that includes statistics on performance
/// </summary>
/// <remarks>
/// Code based on that in Game Development by MonoGame. See https://github.com/Apress/game-dev-monogame
/// </remarks>
public class StatsObject : TextObjectBase
{
    public const int ROLLING_SIZE = 60;

    private readonly Queue<float> _rollingFPS = new();
    public float FPS { get; set; }
    public float MinFPS { get; private set; }
    public float MaxFPS { get; private set; }
    public float AverageFPS { get; private set; }
    public bool IsRunningSlowly { get; set; }
    public int NbUpdateCalled { get; set; }
    public int NbDrawCalled { get; set; }

    public StatsObject(SpriteFont font) : base(font)
    {
        NbUpdateCalled = 0;
        NbDrawCalled = 0;
    }

    public void Update(GameTime gameTime)
    {
        NbUpdateCalled++;
        FPS = 1.0f / (float)gameTime.ElapsedGameTime.TotalSeconds;

        _rollingFPS.Enqueue(FPS);

        if (_rollingFPS.Count > ROLLING_SIZE)
        {
            _rollingFPS.Dequeue();

            float sum = 0.0f;
            MaxFPS = int.MinValue;
            MinFPS = int.MaxValue;
            foreach (float fps in _rollingFPS.ToArray())
            {
                sum += fps;
                if (fps > MaxFPS)
                {
                    MaxFPS = fps;
                }

                if (fps < MinFPS)
                {
                    MinFPS = fps;
                }
            }
            AverageFPS = sum / _rollingFPS.Count;
        }
        else
        {
            AverageFPS = FPS;
            MinFPS = FPS;
            MaxFPS = FPS;
        }

        Text = $"FPS: {FPS:N2} (Min: {MinFPS:N2}, Max: {MaxFPS:N2}, Avg: {AverageFPS:N2})" + Environment.NewLine;
        Text += $"Updates: {NbUpdateCalled}, Draws: {NbDrawCalled}" + Environment.NewLine;
        
        if (IsRunningSlowly)
        {
            Text += "SLOW";
        }
    }

    public override void Render(SpriteBatch spriteBatch)
    {
        NbDrawCalled++;
        base.Render(spriteBatch);
    }
}