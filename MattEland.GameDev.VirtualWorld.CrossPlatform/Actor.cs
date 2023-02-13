using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MattEland.GameDev.VirtualWorld.CrossPlatform
{
    public class Actor : WorldObjectBase
    {
        public Actor() : this(0, 0)
        {
        }
        public Actor(float x, float y) : this(new Vector2(x, y))
        {
        }
        public Actor(Vector2 pos) : base(pos)
        {
        }
    }
}
