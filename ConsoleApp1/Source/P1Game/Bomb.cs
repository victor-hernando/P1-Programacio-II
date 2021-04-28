using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace TcGame
{
    class Bomb : Item
    {
        static Texture tex = new Texture("Data/Textures/Bomb.jpg");

        public Bomb() : base(tex)
        {
        }
       
    }
}
