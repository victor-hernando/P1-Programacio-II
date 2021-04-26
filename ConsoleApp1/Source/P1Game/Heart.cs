using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace TcGame
{
    class Heart : Item
    {
        public Heart(Texture texture, int X, int Y) : base(texture, X, Y)
        {
            Sprite Heart = new Sprite();
            Heart.Texture = texture;
            Heart.Origin = new Vector2f(X/2, Y/2);
        }

    }
}
