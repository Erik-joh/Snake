using System;
using System.Collections.Generic;

namespace Snake
{
    public class GameBoard
    {

        public int Width { get; private set; }
        public int Height {get;  private set; }
        public Tuple<int,int> Food { get; private set; } 


        public GameBoard(int width,int height)
        {
            this.Width = width * 2;
            this.Height = height;
        }
        

        public void RandomizeFood(List<Tuple<int,int>> body)
        {
            var rnd = new Random();
            
            List<Tuple<int,int>> freeSpace = new List<Tuple<int, int>>(); 
            for (int y = 1; y <= Height-1; y++)
            {
                for (int x = 2; x <= Width-2; x = x + 2)
                {
                    if (!body.Exists(tuple => tuple.Item1 == x && tuple.Item2 == y))
                    {
                        freeSpace.Add(new Tuple<int, int>(x,y));
                    }
                }
            }

            Food = freeSpace[rnd.Next(0, freeSpace.Count - 1)];


        }
        public void Draw()
        {
            
            for (int i = 0; i <= Width; i++)
            {
                if (i % 2 > 0)
                {
                    DrawPoint(i,0," ");
                    DrawPoint(i,Height," ");
                }
                else
                {
                    DrawPoint(i,0,"#");
                    DrawPoint(i,Height,"#");
                }
                
            }

            for (int i = 0; i <= Height; i++)
            {
                DrawPoint(0,i,"#");
                DrawPoint(Width,i,"#");
            }
            DrawPoint(Food.Item1,Food.Item2,"*");
            
        }

        private void DrawPoint(int x,int y, string c)
        {
            Console.SetCursorPosition(x,y);
            Console.Write(c);
        }
    }
}