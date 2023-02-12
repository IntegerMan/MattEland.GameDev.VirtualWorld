
using MattEland.GameDev.VirtualWorld.CrossPlatform;

namespace MattEland.GameDev.VirtualWorld.Mono.WinDesktop;

internal class Program
{
    private static void Main()
    {
        using VirtualWorldGame game = new();
        game.Run();
    }
}