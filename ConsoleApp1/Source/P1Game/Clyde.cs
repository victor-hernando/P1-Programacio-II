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
        public Clyde(Texture texture, int X, int Y) : base(texture, X, Y)
        {
            Sprite Clyde = new Sprite();
            Clyde.Texture = texture;
            Clyde.Origin = new Vector2f(X/2, Y/2);
        }
    }
}
