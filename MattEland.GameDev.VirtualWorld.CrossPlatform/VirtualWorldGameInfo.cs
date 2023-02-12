using System;

namespace MattEland.GameDev.VirtualWorld.CrossPlatform
{
    public class VirtualWorldGameInfo
    {
        public Version Version => new(0, 0, 1);
        public string VersionSuffix => " Prototype";
        public string Title => $"Virtual World v{Version}{VersionSuffix} by Matt Eland";

        public int WindowWidth => 800;
        public int WindowHeight => 600;
    }
}