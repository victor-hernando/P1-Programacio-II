using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace TcGame
{
    class Coin : Item
    {
        static Texture tex = new Texture("Data/Textures/Coin.jpg");
        public Coin() : base(tex)
        {
            Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
        }
    }
}
