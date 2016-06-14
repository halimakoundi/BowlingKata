namespace BowlingKata.Src
{
    internal class Frame
    {
        private readonly string _rollsResult;
        private readonly bool _isLastFrame;
        private readonly bool _isOneBeforeLastFrame  ;
        private Roll[] _rolls;

        public Frame(string rollsResult, int index, int gameLength)
        {
            _rollsResult = rollsResult;
            _isLastFrame = index == gameLength - 1;
            _isOneBeforeLastFrame = index == gameLength - 2;
            PopulateRollsScore();
        }

        private void PopulateRollsScore()
        {
            _rolls = new Roll[]
            {
                new Roll(_rollsResult, 0), 
                new Roll(_rollsResult, 1), 
            };
        }

        public int GetRollScore(int index)
        {
            return _rolls[index].GetRollScore();
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
            return Score() == 10 && _rolls[1].GetRollScore() == 0;
        }

        public bool IsOneBeforeLastFrame()
        {
            return _isOneBeforeLastFrame;
        }

        public bool IsStrikeOrSpare()
        {
            return Score() == 10;
        }
    }
}