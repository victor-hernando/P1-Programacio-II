using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace TcGame
{
    class Clyde : Item
    {
        static Texture tex = new Texture("Data/Textures/Clyde.png");
        public Clyde() : base(tex,4)
        {
            Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
        }
    }
}
