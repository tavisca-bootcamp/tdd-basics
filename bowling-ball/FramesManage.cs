using System;

public class FramesManage
{
    public const int FIRSTFRAME = 0;
    public const int SECONDFRAME = 1;
    public const int LASTFRAMEINDEX = 9;
    public const int FRAMESEXCEEDED = 10;
    public const int STRIKEPINS = 10;
    public const int FIRST = 1;
    public const int SECOND = 2;
    public const int COMPLETED = 3;

    public Frame[] FramesList;
    public int PresentFrame = 0;
	public FramesManage(Frame[] frameList)
	{
        FramesList = frameList;
	}

    

    public void UpdateInFrames(Frame frame)
    {
        frame.CalculateRollsScore();
        FramesList[PresentFrame] = frame;
        Frame currentFrame = frame;
        Frame firstPreviousFrame = null;
        Frame SecondPreviousFrame = null;
        if (PresentFrame > FIRSTFRAME)
            firstPreviousFrame = FramesList[PresentFrame - 1];
        if (PresentFrame > SECONDFRAME)
           SecondPreviousFrame = FramesList[PresentFrame - 2];
        ScoresUpdate scoresUpdate = new ScoresUpdate(SecondPreviousFrame, firstPreviousFrame, currentFrame);
        scoresUpdate.UpdatingFrameScores();
        PresentFrame++;

    }

}
