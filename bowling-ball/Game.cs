using System;

namespace BowlingBall
{
    public class Game
    {
         int totalScore = 0,bonus = 0;
        int[,] scoreBoard = new int[10,2];
        static int tryIndex = 0;
        public void Roll(int pins)
        {
            if (tryIndex == 18)
            {
                scoreBoard[9,0] = pins;
                tryIndex++;
            }else

            if (tryIndex == 19)
            {   
                scoreBoard[9, 1] = pins;
                tryIndex++;
            }
            else

            if (tryIndex == 20)
            {
                bonus = pins;
                tryIndex++;
            }
            else
            if (pins == 10 && tryIndex % 2 == 1)
            {
                scoreBoard[tryIndex / 2, 1] = 10;
                tryIndex++;

            }
            else if (pins == 10)
            {
                scoreBoard[tryIndex / 2, 0] = 10;
                //scoreBoard[tryIndex / 2, 1] = -11;

                tryIndex += 2;
            }
            else
            {
                scoreBoard[tryIndex / 2, tryIndex % 2] = pins;
                tryIndex++;
            }
            return;
            throw new NotImplementedException();
        }

        public int GetScore()
        {
            for (int frame = 0; frame < 10; frame++)
            {
                if (frame < 9)
                {

                    if (scoreBoard[frame, 0] == 10)
                    {
                        //Strike Condition
                        totalScore += 10;
                        
                        //int ballCounter = 0;
                        if (scoreBoard[frame + 1, 0] != 10)
                        {
                            //if Next is not Strike
                            totalScore += scoreBoard[frame + 1, 0] + scoreBoard[frame + 1, 1];

                        }
                        else

                        {
                            // If next is also strike
                            if (frame != 8)
                                totalScore += scoreBoard[frame + 2, 0] + 10;
                            else
                                totalScore += scoreBoard[9,0] + scoreBoard[9, 1];

                        }


                    }
                    else
                        if (scoreBoard[frame, 0] + scoreBoard[frame, 1] == 10)
                    {//Spear Condition

                        totalScore += 10 + scoreBoard[frame + 1, 0];

                    }
                    else
                        totalScore += scoreBoard[frame, 0] + scoreBoard[frame, 1];

                }
                else
                {//Special Condition for last frame
                    if (frame == 9)
                    {
                        totalScore += scoreBoard[9, 0] + scoreBoard[9, 1] + bonus;

                    }




                }
            }

            return totalScore;
            throw new NotImplementedException();
         }
        public void MultipleRolls(int [] Rolls)
        {   if (Rolls.Length > 21)
            {
                return;
            }
            tryIndex = 0;
            for (int i = 0; i < Rolls.Length; i++)
            {
                Roll(Rolls[i]);

            }
            return;
            throw new NotImplementedException();

        }
    }
}

