namespace BowlingKata.Src
{
    internal class StrikeFrame : Frame
    {
        private readonly Roll _nextRoll;
        private readonly Roll _secondNextRoll;

        public StrikeFrame(Roll nextRoll, Roll secondNextRoll, Roll[] frameRolls)
            : base(frameRolls)
        {
            _nextRoll = nextRoll;
            _secondNextRoll = secondNextRoll;
        }

        public override int Score()
        {
            return base.Score() + GetNextRollScore() + GetSecondNextRollScore();
        }

        private int GetNextRollScore()
        {
            return _nextRoll.GetRollScore();
        }

        private int GetSecondNextRollScore()
        {
            return _secondNextRoll.GetRollScore();
        }
    }
}