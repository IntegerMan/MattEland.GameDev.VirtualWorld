using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MattEland.GameDev.VirtualWorld.CrossPlatform
{

    public class TileInfo : WorldObjectBase
    {
        public TileInfo(TileType tileType) : this(0,0, tileType)
        {
        }
        public TileInfo(float x, float y, TileType tileType) : this(new Vector2(x, y), tileType)
        {
        }
        public TileInfo(Vector2 pos, TileType tileType) : base(pos)
        {
            TileType = tileType;
        }

        public TileType TileType { get; }
    }
}
