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
        public Coin(Texture texture, int X, int Y) : base(texture, X, Y)
        {
            Sprite Coin = new Sprite();
            Coin.Texture = texture;
            Coin.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
        }
    }
}
