using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    class Program
    {
        static void Main(string[] args)
        {
            RollingBall balls = new RollingBall();
                balls.RollingAStrike();
                balls.RollingASpare(9);
                balls.RollingASpare(5);
                balls.RollsNormal(7);
                balls.RollsNormal(2);
                balls.RollingAStrike();
                balls.RollingAStrike();
                balls.RollingAStrike();
                balls.RollsNormal(9);
                balls.RollsNothing();
                balls.RollingASpare(8);
                balls.RollingASpare(9);
                balls.RollingAStrike();

            //var values = balls.GetValues();
            //foreach (var v in values)
            //{
            //    Console.WriteLine($"{i++} : {v}");
            //}
            
            int scores = balls.GetScore();
            Console.WriteLine($"Total Score : {scores}");
            Console.ReadLine();
            }
    }
}
