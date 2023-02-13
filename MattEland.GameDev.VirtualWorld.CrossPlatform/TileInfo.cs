using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MattEland.GameDev.VirtualWorld.CrossPlatform
{
    public class TileInfo
    {
        public TileInfo() : this(0,0)
        {
        }
        public TileInfo(float x, float y) : this(new Vector2(x, y))
        {
        }
        public TileInfo(Vector2 pos)
        {
            Position = pos;
        }

        public Vector2 Position { get; }

        public Vector2 ToScreenPos(int tileSize)
        {
            return new Vector2(Position.X * tileSize, Position.Y * tileSize);
        }
    }
}
