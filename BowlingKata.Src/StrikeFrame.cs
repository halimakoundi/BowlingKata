namespace BowlingKata.Src
{
    internal class StrikeFrame : Frame
    {
        private readonly Roll _nextRollResults;
        private Roll _secondNextRollScore;

        public StrikeFrame(string rollsResult, int index, int gameLength, string[] gameResults, Roll[] bonusRolls) : base(rollsResult, index, gameLength)
        {
            _nextRollResults = !IsLastFrame() ?
                                    new Roll(gameResults[index + 1], 0)
                                    : bonusRolls[0];
            _secondNextRollScore = !IsLastFrame() ?
                                    new Roll(gameResults[index + 1], 1)
                                    : bonusRolls[1];
            PopulateNextRollScore();
        }

        protected void PopulateNextRollScore()
        {
            Rolls = new Roll[]
            {
                new Roll(RollsResult, 0),
                new Roll(RollsResult, 1),
                _nextRollResults,
                _secondNextRollScore
            };

        }

        public override int GetNextRollScore()
        {
            return Rolls[2].GetRollScore();
        }
    }
}