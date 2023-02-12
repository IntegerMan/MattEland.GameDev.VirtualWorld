
using MattEland.GameDev.VirtualWorld.Mono.Desktop;

internal class Program
{
    private static void Main()
    {
        using VirtualWorldGame game = new();
        game.Run();
    }
}