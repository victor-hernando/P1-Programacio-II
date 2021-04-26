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
        public Axe(Texture texture, int X, int Y) : base(texture, X, Y)
        {
            Sprite Axe = new Sprite();
            Axe.Texture = texture;
            Axe.Origin = new Vector2f(X / 2, Y / 2);
        }
    }
}
