
internal class Program
{
    private static void Main(string[] args)
    {
        using var game = new MattEland.GameDev.VirtualWorld.Mono.Desktop.VirtualWorldGame();
        game.Run();
    }
}