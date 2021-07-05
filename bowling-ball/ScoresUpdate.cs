using System;

internal class ScoresUpdate
{
    private Frame secondPreviousFrame;
    private Frame firstPreviousFrame;
    private Frame currentFrame;

    public ScoresUpdate(Frame secondPreviousFrame, Frame firstPreviousFrame, Frame currentFrame)
    {
        this.secondPreviousFrame = secondPreviousFrame;
        this.firstPreviousFrame = firstPreviousFrame;
        this.currentFrame = currentFrame;
        
    }

    public  void UpdatingFrameScores()
    {
        if (secondPreviousFrame != null)
            UpdateSecondPreviousFrame();

        if (firstPreviousFrame != null)
            UpdateFirstPreviousFrame();

            updateCurrentFrame();
    }

    private void UpdateSecondPreviousFrame()
    {
        if (secondPreviousFrame.IsStrike() && firstPreviousFrame.IsStrike())
            secondPreviousFrame.Score += currentFrame.FirstRoll;
    }


    private void UpdateFirstPreviousFrame()
    {
        switch (firstPreviousFrame)
        {
            case var f when f.IsStrike():
                firstPreviousFrame.Score += currentFrame.Score;
                if (secondPreviousFrame!=null && secondPreviousFrame.IsStrike())
                    firstPreviousFrame.Score += currentFrame.FirstRoll;
                break;

            case var f when f.IsSpare():
                firstPreviousFrame.Score += currentFrame.FirstRoll;
                break;

        }
    }

    private void updateCurrentFrame()
    {      if (firstPreviousFrame != null)
            currentFrame.Score += firstPreviousFrame.Score;
    }

    

   
}