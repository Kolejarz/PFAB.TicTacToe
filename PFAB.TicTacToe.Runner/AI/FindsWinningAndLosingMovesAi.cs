using System.Drawing;
using PFAB.TicTacToe.Engine;

namespace PFAB.TicTacToe.Runner.AI
{
    internal class FindsWinningAndLosingMovesAi : FindsWinningMovesAi
    {
        private readonly char _opponent;

        public FindsWinningAndLosingMovesAi(int winningSequenceLength, char opponent) : base(winningSequenceLength)
        {
            _opponent = opponent;
        }

        public new Point GetCoordinates(IBoard board, char player)
        {
            return FindWinningMove(board, player) ??
                   FindWinningMove(board, _opponent) ??
                   RandomAi.GetCoordinates(board, player);
        }
    }
}
