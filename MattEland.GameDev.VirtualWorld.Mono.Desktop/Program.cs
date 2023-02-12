
using MattEland.GameDev.VirtualWorld.CrossPlatform;

internal class Program
{
    private static void Main()
    {
        using VirtualWorldGame game = new();
        game.Run();
    }
}