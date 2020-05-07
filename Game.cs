using System;

namespace Snake
{    
    
    public class Game
    {
        ScheduleTimer _timer;

        private bool _turned = false;
        public bool Paused { get; private set; }

        private int _score = 0;
        private GameBoard _gameBoard = new GameBoard(30,30);
        private Snake _snake; 
        public void Start()
        {
            this._snake = new Snake(_gameBoard.Width/2,_gameBoard.Height/2,3);
            _gameBoard.RandomizeFood(_snake.GetSnake());
            Console.WriteLine("Start");
            ScheduleNextTick();
        }

        public void Input(ConsoleKey key)
        {
            if(!_turned){
                if (key == ConsoleKey.UpArrow && _snake.Dir.Item2 != 1)
                {
                    _snake.Dir = new Tuple<int, int>(0,-1);
                }else if (key == ConsoleKey.DownArrow && _snake.Dir.Item2 != -1)
                {
                    _snake.Dir = new Tuple<int, int>(0, 1);
                }else if (key == ConsoleKey.RightArrow && _snake.Dir.Item1 != -2)
                {
                    _snake.Dir = new Tuple<int, int>(2,0);
                }else if (key == ConsoleKey.LeftArrow && _snake.Dir.Item1 != 2)
                {
                    _snake.Dir = new Tuple<int, int>(-2,0);
                }

                _turned = true;
            }
        }

        public void Pause()
        {
            Console.WriteLine("Pause");
            _timer.Pause();
            Paused = true;
        }

        public void Resume()
        {
            Console.WriteLine("Resume");
            _timer.Resume();
            Paused = false;
        }

        public void Stop()
        {
            Console.WriteLine("Stop");
        }

        void Tick()
        {
            Console.Clear();
            _gameBoard.Draw();
            _snake.Move();
            if (_snake.Eat(_gameBoard.Food.Item1, _gameBoard.Food.Item2))
            {
                _gameBoard.RandomizeFood(_snake.GetSnake());
                _score += 10;
            }
            _snake.Draw();
            _turned = false;
            Console.SetCursorPosition(_gameBoard.Width + 2,1);
            Console.Write($"Score: {_score}");
            Console.SetCursorPosition(0,0);
            if (!_snake.Collided(0, _gameBoard.Width, 0, _gameBoard.Height))
            {
                ScheduleNextTick();    
            }
            else
            {
                Console.SetCursorPosition(_gameBoard.Width +2, 3);
                Console.Write("Game Over!");    
            }
            
            
        }

        void ScheduleNextTick()
        {
            _timer = new ScheduleTimer(100, Tick);
        }
    }
}