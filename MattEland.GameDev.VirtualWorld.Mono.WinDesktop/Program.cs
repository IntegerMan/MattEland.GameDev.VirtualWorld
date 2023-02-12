
using MattEland.GameDev.VirtualWorld.Mono.Desktop;

namespace MattEland.GameDev.VirtualWorld.Mono.WinDesktop;

internal class Program
{
    private static void Main()
    {
        using VirtualWorldGame game = new();
        game.Run();
    }
}