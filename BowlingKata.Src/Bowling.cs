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
                _gameScore += GetAdditionalFrameScore(frame, i);
            }
            return _gameScore;
        }

        private int GetAdditionalFrameScore(Frame frame, int frameIndex)
        {
            var additionalFrameScore = 0;
            if (!frame.IsStrikeOrSpare()) return additionalFrameScore;
            var nextFrame = GetNextFrame(frame, frameIndex);
            additionalFrameScore = GetNextRollScore(frame, nextFrame);

            if (frame.IsStrike())
            {
                additionalFrameScore += GetSecondNextRollScore(frame, frameIndex, nextFrame);
            }
            return additionalFrameScore;
        }

        private int GetSecondNextRollScore(Frame frame, int frameIndex, Frame nextFrame)
        {
            if (!frame.IsLastFrame() && nextFrame.IsStrike())
            {
                return frame.IsOneBeforeLastFrame() ? _bonusRolls[0].GetRollScore() : _frames[frameIndex + 2].GetRollScore(0);
            }
            return !frame.IsLastFrame()
                ? nextFrame.GetRollScore(1)
                : _bonusRolls[1].GetRollScore();
        }

        private static int GetNextRollScore(Frame frame, Frame nextFrame)
        {
            return !frame.IsLastFrame()
                ? nextFrame.GetRollScore(0)
                : _bonusRolls[0].GetRollScore();
        }

        private Frame GetNextFrame(Frame frame, int frameIndex)
        {
            return !frame.IsLastFrame()
                ? _frames[frameIndex + 1]
                    : null;
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
                  .Select((x, index) => Frame.Parse(x, index, gameResults.Length, gameResults)).ToArray();
        }
    }
}