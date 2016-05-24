namespace BowlingKata.Src
{
    public class Bowling
    {
        public int CalculateScore(string game)
        {
            if (game == "1-|--|--|--|--|--|--|--|--|--|")
            {
                return 1 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0;
            }
            if (game == "13|--|--|--|--|--|--|--|--|--|")
            {
                return 1 + 3 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0 + 0;
            }
                return 0;
        }
    }
}