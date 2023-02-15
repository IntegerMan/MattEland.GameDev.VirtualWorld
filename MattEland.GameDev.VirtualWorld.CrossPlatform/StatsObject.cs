namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

/// <summary>
/// A displayable object that includes statistics on performance
/// </summary>
/// <remarks>
/// Code based on that in Game Development by MonoGame. See https://github.com/Apress/game-dev-monogame
/// </remarks>
public class StatsObject : TextObjectBase
{
    public const int FramesToObserve = 60;

    private readonly StringBuilder _sb = new();

    private readonly Queue<float> _rollingFPS = new();
    public float FPS { get; private set; }
    public float MinFPS { get; private set; }
    public float MaxFPS { get; private set; }
    public float AverageFPS { get; private set; }
    public string Title { get; set; }

    public StatsObject(SpriteFont font, Vector2 position) : base(font, position)
    {
    }
    
    public override void Update(GameTime gameTime)
    {
        //NbUpdateCalled++;
        FPS = 1.0f / (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Ensure that we don't consider invalid FPS values
        if (float.IsNaN(FPS)) return;

        _rollingFPS.Enqueue(FPS);

        if (_rollingFPS.Count <= FramesToObserve)
        {
            // We're still spinning up so just use our FPS
            AverageFPS = FPS;
            MinFPS = FPS;
            MaxFPS = FPS;
        }
        else
        {
            // Remove the last frame from the history
            _rollingFPS.Dequeue();

            // Calculate our metrics from the observable window
            MaxFPS = _rollingFPS.Max();
            MinFPS = _rollingFPS.Min();
            AverageFPS = _rollingFPS.Average();
        }

        _sb.Clear();
        _sb.AppendLine(Title);
        _sb.AppendLine($"FPS: {FPS:N2} (Min: {MinFPS:N2}, Max: {MaxFPS:N2}, Avg: {AverageFPS:N2})");

        Text = _sb.ToString();
    }

}