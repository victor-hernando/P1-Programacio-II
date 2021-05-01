﻿using System;
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
        static Texture texture = new Texture("Data/Textures/Sword.png");
        public Sword() : base(texture)
        {
            Origin = new Vector2f(GetLocalBounds().Width/2, GetLocalBounds().Height/2) / 2.0f;
        }
    }
}
