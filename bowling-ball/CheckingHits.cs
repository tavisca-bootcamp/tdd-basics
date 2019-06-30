using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    class CheckingHits
    {
        Game game = new Game();

           
        public  int[] _roll;

         public CheckingHits(int [] rollings)
        {
            _roll = rollings;
        }

        public bool IsSpare(int rollIndex)
        {
            return (_roll[rollIndex] + _roll[rollIndex + 1] == 10) ? true : false;
        }

        public bool IsStrike(int rollIndex)
        {
            return (_roll[rollIndex] == 10) ? true : false;
        }

        public int GetSpareBonus(int rollIndex)
        {
            return _roll[rollIndex + 2];
        }
        
        public int GetStrikeBonus(int rollIndex)
        {
            return _roll[rollIndex + 1] +  _roll[rollIndex + 2];
            
        }

        public int[] GetValues()
        {
            return _roll;
        }


    }
}
