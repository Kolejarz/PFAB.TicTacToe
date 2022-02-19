using System.Drawing;
using PFAB.TicTacToe.Engine;

namespace PFAB.TicTacToe.Runner.AI
{
    internal class RandomAi : ICoordinatesProvider
    {
        private readonly Random _random = new ();

        public Point GetCoordinates(IBoard board, char _)
        {
            var squares = board.GetSquares();
            var emptySquares = new List<Point>();

            for (var y = 0; y < squares.Length; y++)
            {
                for (var x = 0; x < squares[y].Length; x++)
                {
                    if (!squares[y][x].IsOccupied)
                    {
                        emptySquares.Add(new Point(x, y));
                    }
                }
            }

            var result = emptySquares[_random.Next() % emptySquares.Count];
            return result;
        }
    }
}
