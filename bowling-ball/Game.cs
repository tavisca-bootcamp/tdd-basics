using System;

namespace BowlingBall
{
    public class Game
    {
        public void Roll(int pins)
        {
            int[] frameOpportunityOne = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            int[] frameOpportunityTwo = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
            int oneExtraShot = 0;
        }

        public int GetScore(int[] frameOpportunityOne, int[] frameOpportunityTwo, int oneExtraShot)
        {
            int[] eachFrameScore = new int[frameOpportunityOne.Length];
            int score = 0;
            for(int i=0; i<eachFrameScore.Length; i++){
                if(i == frameOpportunityOne.Length-1){
                    if(frameOpportunityOne[i] == 10){
                        score += 10 + oneExtraShot;
                       
                        eachFrameScore[i] = score;
                    }
                    else if(frameOpportunityOne[i] + frameOpportunityTwo[i] == 10){
                        score += frameOpportunityOne[i] + frameOpportunityTwo[i] + oneExtraShot;
                        
                        eachFrameScore[i] = score;
                    }
                    else if(frameOpportunityOne[i] + frameOpportunityTwo[i] < 10){
                        score += frameOpportunityOne[i] + frameOpportunityTwo[i];

                        eachFrameScore[i] = score;
                    }
                    else{
                        return -1;
                    }
                }
                else if(i == frameOpportunityOne.Length-2){
                    if(frameOpportunityOne[i] == 10){
                        if(frameOpportunityOne[i+1] == 10){
                            score += 10 + frameOpportunityOne[i+1] + oneExtraShot;
                        }
                        else{
                            score += 10 + frameOpportunityOne[i+1] + frameOpportunityTwo[i+1];
                        }

                        eachFrameScore[i] = score;
                    }
                    else if(frameOpportunityOne[i] + frameOpportunityTwo[i] == 10){
                        score += frameOpportunityOne[i] + frameOpportunityTwo[i] + frameOpportunityOne[i+1];
                        
                        eachFrameScore[i] = score;
                    }
                    else if(frameOpportunityOne[i] + frameOpportunityTwo[i] < 10){
                        score += frameOpportunityOne[i] + frameOpportunityTwo[i];

                        eachFrameScore[i] = score;
                    }
                    else{
                        return - 1;
                    }
                }
                else{
                    if(frameOpportunityOne[i] == 10){
                        if(frameOpportunityOne[i+1] == 10){
                            score += 10 + frameOpportunityOne[i+1] + frameOpportunityOne[i+2];
                        }
                        else{
                            score += 10 + frameOpportunityOne[i+1] + frameOpportunityTwo[i+1];
                        }

                        eachFrameScore[i] = score;
                    }
                    else if(frameOpportunityOne[i] + frameOpportunityTwo[i] == 10){
                        score += frameOpportunityOne[i] + frameOpportunityTwo[i] + frameOpportunityOne[i+1];
                        
                        eachFrameScore[i] = score;
                    }
                    else if(frameOpportunityOne[i] + frameOpportunityTwo[i] < 10){
                        score += frameOpportunityOne[i] + frameOpportunityTwo[i];

                        eachFrameScore[i] = score;
                    }
                    else{
                        return -1;
                    }
                }
            }

            return score;
        }
    }
}

