using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MattEland.GameDev.VirtualWorld.CrossPlatform
{
    public enum TileType
    {
        Wall,
        Floor
    }

    public class TileInfo
    {
        public TileInfo(TileType tileType) : this(0,0, tileType)
        {
        }
        public TileInfo(float x, float y, TileType tileType) : this(new Vector2(x, y), tileType)
        {
        }
        public TileInfo(Vector2 pos, TileType tileType)
        {
            Position = pos;
            TileType = tileType;
        }

        public Vector2 Position { get; }
        public TileType TileType { get; }

        public Vector2 ToScreenPos(int tileSize)
        {
            return new Vector2(Position.X * tileSize, Position.Y * tileSize);
        }
    }
}
