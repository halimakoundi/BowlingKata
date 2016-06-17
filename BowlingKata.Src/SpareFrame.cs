namespace BowlingKata.Src
{
    internal class SpareFrame : Frame
    {
        private readonly Roll _nextRollResults;

        public SpareFrame(string frameRolls, Roll nextRoll) 
            : base(frameRolls)
        {
            _nextRollResults = nextRoll;
        }

        public override int Score()
        {
            return base.Score() + GetNextRollScore();
        }

        private int GetNextRollScore()
        {
            return _nextRollResults.GetRollScore();
        }
    }
}