using SFML.Graphics;
using System;

namespace TcGame
{
  public abstract class Item : Sprite
  {
        public int order;
        public Item(Texture texture, int ordre)
        {
            Texture = texture;
            order = ordre;
        }
  }
}
