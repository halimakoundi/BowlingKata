namespace BowlingKata.Src
{
    internal class SpareFrame : Frame
    {
        private readonly Roll _nextRoll;

        public SpareFrame(Roll nextRoll, Roll[] frameRolls) 
            : base(frameRolls)
        {
            _nextRoll = nextRoll;
        }

        public override int Score()
        {
            return base.Score() + GetNextRollScore();
        }

        private int GetNextRollScore()
        {
            return _nextRoll.GetRollScore();
        }
    }
}