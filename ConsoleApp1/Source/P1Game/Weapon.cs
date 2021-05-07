using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace TcGame
{
    abstract class Weapon : Item
    {
        public Weapon(Texture tex, int ord) : base(tex,ord)
        {
        }
    }
}
