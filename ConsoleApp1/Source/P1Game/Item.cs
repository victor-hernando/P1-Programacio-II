using SFML.Graphics;
using System;

namespace TcGame
{
  public abstract class Item : Sprite
  {
        public Item(Texture texture)
        {
            Texture = texture;
        }
  }
}
