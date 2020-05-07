using System;
using System.Collections.Generic;
using System.Xml;


namespace Snake
{
    class Program
    {
        

        static void Main(string[] args)
        {

            


            //PaintGameBoard(gameBoard);

            var game = new Game();

            game.Start();

            // game loop
            while (true)
            {
                
                //PaintGameBoard(gameBoard);
                // listen to key presses
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        // pause and unpause the game with P
                        case ConsoleKey.P:

                            if (game.Paused)
                                game.Resume();
                            else
                                game.Pause();

                            break;

                        // send key strokes to the game if it's not paused
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.Spacebar:

                            if (!game.Paused)
                                game.Input(key.Key);

                            break;

                        // end the game with ESC
                        case ConsoleKey.Escape:

                            game.Stop();
                            return;
                    }
                }
            }
        }
    }
}