using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace TcGame
{
    class Sword : Weapon
    {
        private Texture texture = new Texture("Data/Textures/Sword.jpg");
        public Sword() : base(texture)
        {
            Sprite Sowrd = new Sprite();
            Sowrd.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
        }
    }
}
