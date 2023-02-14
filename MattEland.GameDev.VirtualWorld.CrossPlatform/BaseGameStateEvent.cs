namespace MattEland.GameDev.VirtualWorld.CrossPlatform;

/// <summary>
/// Game state events
/// </summary>
/// <remarks>
/// Code based on that in Game Development by MonoGame. See https://github.com/Apress/game-dev-monogame
/// </remarks>

public class BaseGameStateEvent
{
    public class Nothing : BaseGameStateEvent { }
    public class GameQuit : BaseGameStateEvent { }
    public class GameTick : BaseGameStateEvent { }
}