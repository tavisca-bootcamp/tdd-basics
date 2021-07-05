using System;
using System.Collections.Generic;
public class Frame
{
    public int FirstRoll=0;
    public int SecondRoll=0;
    public int Score = 0;

    public void DoFirstRoll(int pins)
    {
        FirstRoll = pins;
    }


    public void DoSecondRoll(int pins)
    {
        SecondRoll = pins;
    }
    public void CalculateRollsScore()
    {
        Score = FirstRoll + SecondRoll;
    }

    public void TenthFrameUpdate(int pins)
    {
        Score += pins;
    }

    public bool IsSpare()
    {    if (FirstRoll == 10)
            return false;
        return FirstRoll + SecondRoll == 10;
    }

    public bool IsStrike()
    {
        return FirstRoll == 10;
    }

    
}
