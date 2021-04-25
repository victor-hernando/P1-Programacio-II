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
        public static Item generateRandomType()
        {
           switch (rnd.Next(6))
            {
                case 0:
                    return new Blinky();
                case 1:
                    return new Blinky;
                case 2:
                    return new Blinky;
                case 3:
                    return new Blinky;
                case 4:
                    return new Blinky;
                case 5:
                    return new Blinky;
                default:
                    return null;
            }
        }
  }
}
