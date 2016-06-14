namespace BowlingKata.Src
{
    internal class StrikeFrame : Frame
    {
        private readonly string _nextRollResults;

        public StrikeFrame(string rollsResult, int index, int gameLength, string[] gameResults, string[] bonusRolls) : base(rollsResult, index, gameLength)
        {
            _nextRollResults = !IsLastFrame() ?
                               gameResults[index + 1]
                               : bonusRolls[0];
            PopulateNextRollScore();
        }

        protected void PopulateNextRollScore()
        {
            Rolls = new Roll[]
            {
                new Roll(RollsResult, 0),
                new Roll(RollsResult, 1),
                new Roll(_nextRollResults, 0),
            };

        }
    }
}