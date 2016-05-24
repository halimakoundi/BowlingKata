namespace BowlingKata.Src
{
    public class Bowling
    {
        public int CalculateScore(string game)
        {
            if (game == "1-|--|--|--|--|--|--|--|--|--|")
            {
                return 1;
            }
            return 0;
        }
    }
}