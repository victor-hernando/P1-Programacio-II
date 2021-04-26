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
        public Bomb(Texture texture, int X, int Y) : base(texture, X, Y)
        {
            Sprite Bomb = new Sprite();
            Bomb.Texture = texture;
            Bomb.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
        }
       
    }
}
