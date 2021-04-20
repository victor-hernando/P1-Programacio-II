using System;
using System.Threading;
using SFML.System;

namespace TcGame
{
  public class Engine
  {
    public void Run(Game game)
    {
      game.Init();

      if (game != null)
      {
        const int FPS = 60;
        const double deltaTime = 1.0 / FPS;

        const double maxTimeDiff = 5.0;
        const int maxSkippedFrames = 5;

        DateTime initialTime = DateTime.Now;
        int skippedFrames = 1;
        double nextTime = (DateTime.Now - initialTime).TotalMilliseconds / 1000.0;

        // Game Loop
        while (game.IsAlive())
        {
          double currTime = (DateTime.Now - initialTime).TotalMilliseconds / 1000.0;

          if ((currTime - nextTime) > maxTimeDiff)
          {
            nextTime = currTime;
          }

          if (currTime >= nextTime)
          {
            nextTime += deltaTime;

            // Update step
            game.Update((float)deltaTime);
            if ((currTime < nextTime) || (skippedFrames > maxSkippedFrames))
            {
              // Draw step
              game.Draw();
              skippedFrames = 1;
            }
            else
            {
              skippedFrames++;
            }
          }
          else
          {
            int sleepTime = (int)(1000.0 * (nextTime - currTime));
            if (sleepTime > 0)
            {
              Thread.Sleep(sleepTime);
            }
          }
        }
      }

      game.DeInit();
    }
  }
}
