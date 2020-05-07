using System;
using System.Collections.Generic;


namespace Snake
{
    public class Snake
    {
        private List<Tuple<int, int>> Body;

        public Tuple<int, int> Dir { get; set; }
        

        public Snake(int startX,int startY, int startLength)
        {
            this.Body = new List<Tuple<int, int>>();
            this.Dir = new Tuple<int, int>(2, 0);
            for (int i = 0; i < startLength; i++)
            {
                this.AddToBody(startX - i * 2,startY);    
            }
        }

        private void AddToBody(int x, int y)
        {
            this.Body.Add(new Tuple<int, int>(x,y));
        }

        public List<Tuple<int,int>> GetSnake()
        {
            return this.Body;
        }
        private Tuple<int, int> GetHead()
        {
            return this.Body[0];
        }

        public bool Eat(int x, int y)
        {
            int headX = GetHead().Item1;
            int headY = GetHead().Item2;
            if (headX == x && headY == y)
            {
                AddToBody(x,y);
                return true;
            }

            return false;

        }

        public bool Collided(int left,int right,int top ,int bottom)
        {
            int headX = GetHead().Item1;
            int headY = GetHead().Item2;
            if (headX == left || headX == right)
            {
                return true;
            }

            if (headY == top || headY == bottom)
            {
                return true;
            }

            for (int i = 1; i < Body.Count - 1; i++)
            {
                int bodyX = Body[i].Item1;
                int bodyY = Body[i].Item2;
                if (headX == bodyX && headY == bodyY)
                {
                    return true;
                }
            }

            return false;
        }

        public void Draw()
        {
            foreach (var part in Body)
            {
                Console.SetCursorPosition(part.Item1,part.Item2);
                Console.Write("■");
            }
        }

        public void Move()
        {
            
            for (int i = Body.Count - 1; i > 0; i--)
            {
                Body[i] = new Tuple<int, int>(Body[i - 1].Item1,Body[i - 1].Item2);
            }
            
            Body[0] = new Tuple<int, int>(GetHead().Item1 + Dir.Item1 , GetHead().Item2 + Dir.Item2);
        }
        
    }
}