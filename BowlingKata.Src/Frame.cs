namespace BowlingKata.Src
{
    internal class Frame
    {
        protected readonly string RollsResult;
        private readonly bool _isLastFrame;
        private readonly bool _isOneBeforeLastFrame  ;
        protected Roll[] Rolls;

        public Frame(string rollsResult, int index, int gameLength)
        {
            RollsResult = rollsResult;
            _isLastFrame = index == gameLength - 1;
            _isOneBeforeLastFrame = index == gameLength - 2;
            PopulateRollsScore();
        }

        protected virtual void PopulateRollsScore()
        {
            Rolls = new Roll[]
            {
                new Roll(RollsResult, 0), 
                new Roll(RollsResult, 1), 
            };
        }

        public int GetRollScore(int index)
        {
            return Rolls[index].GetRollScore();
        }

        public int Score()
        {
            return GetRollScore(0) + GetRollScore(1);
        }

        public bool IsLastFrame()
        {
            return _isLastFrame;
        }

        public bool IsStrike()
        {
            return Score() == 10 && Rolls[1].GetRollScore() == 0;
        }

        public bool IsOneBeforeLastFrame()
        {
            return _isOneBeforeLastFrame;
        }

        public bool IsStrikeOrSpare()
        {
            return Score() == 10;
        }

        public static Frame Parse(string frameRolls, int frameIndex, int gameLength, string[] gameResults, Roll[] bonusRolls)
        {
            if (frameRolls.Length == 1 && frameRolls[0] == 'X')
            {
                return new StrikeFrame(frameRolls, frameIndex, gameLength, gameResults, bonusRolls);
            }
            if (frameRolls.Length > 1 && frameRolls[1] == '/')
            {
                return new SpareFrame(frameRolls, frameIndex, gameLength, gameResults, bonusRolls);
            }
            return new Frame(frameRolls, frameIndex, gameLength);
        }

        public virtual int GetNextRollScore()
        {
            return 0;
        }
    }
}