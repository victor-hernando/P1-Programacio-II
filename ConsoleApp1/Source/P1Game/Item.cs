using SFML.Graphics;
using System;

namespace TcGame
{
  public abstract class Item : Sprite
  {
        static Random rnd = new Random();
        Texture tex;
        int sizeX;
        int sizeY;
        public Item(Texture texture, int X, int Y)
        {
            tex = texture;
            sizeX = X;
            sizeY = Y;
        }
  }
}
