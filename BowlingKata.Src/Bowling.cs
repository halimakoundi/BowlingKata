using System;
using System.Linq;

namespace BowlingKata.Src
{
    public class Bowling
    {
        private int _gameScore;
        private string _gameResults;
        private Frame[] _frames;
        private static Roll[] _bonusRolls;

        public int CalculateScore(string game)
        {
            _gameResults = game.Split(new string[] { "||" },
                StringSplitOptions.RemoveEmptyEntries)[0];
            _bonusRolls = GetBonusRolls(game);

            _frames = GetFrames();
            for (var i = 0; i < _frames.Length; i++)
            {
                var frame = _frames[i];
                _gameScore += frame.Score();
                _gameScore += frame.GetAdditionalFrameScore();
            }
            return _gameScore;
        }

        private static Roll[] GetBonusRolls(string game)
        {
            var games = game.Split(new string[] { "||" },
                StringSplitOptions.RemoveEmptyEntries);
            return games.Length > 1 ? 
                                    new Roll[]
                                    {
                                        new Roll(games[1], 0),
                                        new Roll(games[1], 1)
                                    }
                                    : null;
        }

        private Frame[] GetFrames()
        {
            var gameResults = _gameResults.Split(new string[] { "|" },
                  StringSplitOptions.RemoveEmptyEntries);

            return gameResults
                  .Select((x, index) => Frame.Parse(x, index, gameResults.Length, gameResults, _bonusRolls)).ToArray();
        }
    }
}