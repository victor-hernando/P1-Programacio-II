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
        public Weapon(Texture texture, int X, int Y) : base(texture, X, Y)
        {
            Sprite Weapon = new Sprite();
            Weapon.Texture = texture;
            Weapon.Origin = new Vector2f(X / 2, Y / 2);
        }
    }
}
