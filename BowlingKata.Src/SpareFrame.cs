namespace BowlingKata.Src
{
    internal class SpareFrame : Frame
    {
        private readonly Roll _nextRollResults;

        public SpareFrame(string rollsResult, int index, int gameLength, string[] gameResults, Roll[] bonusRolls) : base(rollsResult, index, gameLength)
        {
            _nextRollResults = !IsLastFrame() ?
                               new Roll(gameResults[index + 1], 0)
                               : bonusRolls[0];
            PopulateNextRollScore();
        }

        private void PopulateNextRollScore()
        {
            Rolls = new Roll[]
            {
                new Roll(RollsResult, 0),
                new Roll(RollsResult, 1),
                _nextRollResults,
            };

        }

        public override int Score()
        {
            return base.Score() + GetNextRollScore();
        }

        private int GetNextRollScore()
        {
            return Rolls[2].GetRollScore();
        }

    }
}