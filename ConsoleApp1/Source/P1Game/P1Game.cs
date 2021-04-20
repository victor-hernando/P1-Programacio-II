using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace TcGame
{
  public class P1Game : Game
  {
    public static Vector2u ScreenSize = new Vector2u(1024, 768);
    private RenderWindow window;
    private Grid grid;

    public void Init()
    {
      // Window initialization
      VideoMode videoMode = new VideoMode(ScreenSize.X, ScreenSize.Y);
      window = new RenderWindow(videoMode, "P1");

      // Grid initialization
      grid = new Grid();
      grid.Init();

      // Key Binding
      window.KeyPressed += grid.HandleKeyPressed;
    }

    public void DeInit()
    {
      grid.DeInit();
      window.Dispose();
    }

    public void Update(float dt)
    {
      if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
      {
        window.Close();
      }

      // Needed for Input (key/mouse) events
      window.DispatchEvents();

      grid.Update(dt);
    }

    public void Draw()
    {
      window.Clear();
      window.Draw(grid);
      window.Display();
    }

    public bool IsAlive()
    {
      return window.IsOpen;
    }
  }
}

