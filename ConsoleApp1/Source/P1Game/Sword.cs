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
        public Sword(Texture texture, int X, int Y) : base(texture, X, Y)
        {
            Sprite Sowrd = new Sprite();
            Sowrd.Texture = texture;
            Sowrd.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
        }
    }
}
