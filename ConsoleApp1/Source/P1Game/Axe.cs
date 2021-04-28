using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace TcGame
{
    class Axe : Weapon
    {
        static Texture tex = new Texture("Data/Textures/Axe.jpg");
        public Axe() : base(tex)
        {
            Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
        }
    }
}
