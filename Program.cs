using System;
using engine;

namespace engine
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new Game(800, 800, "LearnOpenTK", 60.0))
            {
                game.Run();
            }

        }
    }
}
