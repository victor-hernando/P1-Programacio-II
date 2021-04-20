using System;
using SFML.Window;
using SFML.System;

namespace TcGame
{
  public static class MathUtil
  {
    /** Constant for Degrees to Radians conversion*/
    public static float DEG2RAD = (float)(Math.PI / 180.0f);

    /** Constant for Radians to Degrees conversion*/
    public static float RAD2DEG = (float)(180.0f / Math.PI);

    /** Returns the Magnitude of the vector*/
    public static float Size(this Vector2f vector)
    {
      return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
    }

    /** Returns the normalized unit vector*/
    public static Vector2f Normal(this Vector2f vector)
    {
      Vector2f result = vector;

      float size = vector.Size();
      if (size > 0.0f)
      {
        result.X /= size;
        result.Y /= size;
      }

      return result;
    }

    /** Rotates the vector angle Degrees*/
    public static Vector2f Rotate(Vector2f v, float angle)
    {
      float sin0 = (float)Math.Sin(angle * DEG2RAD);
      float cos0 = (float)Math.Cos(angle * DEG2RAD);

      if (cos0 * cos0 < 0.001f * 0.001f)
        cos0 = 0.0f;

      Vector2f result = new Vector2f();
      result.X = cos0 * v.X - sin0 * v.Y;
      result.Y = sin0 * v.X + cos0 * v.Y;
      return result;
    }
  }
}
  