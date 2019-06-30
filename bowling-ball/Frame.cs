using System;
using System.Collections.Generic;
public class Frame
{
    public int FirstRoll=0;
    public int SecondRoll=0;
    public int Score=0;
    
    public void CalculateScore()
    {
        Score = FirstRoll + SecondRoll;
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
