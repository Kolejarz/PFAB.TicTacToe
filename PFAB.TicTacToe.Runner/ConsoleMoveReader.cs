using System.Drawing;
using PFAB.TicTacToe.Engine;

namespace PFAB.TicTacToe.Runner
{
    internal class ConsoleMoveReader : ICoordinatesProvider
    {
        public Point GetCoordinates(IBoard _, char _1)
        {
            Console.Write("Please enter your move: ");
            var input = Console.ReadLine();

            var parts = input?.ToUpper().ToCharArray() ?? new[] { 'A', '1' };
            return new Point(parts[1] - '1', parts[0] - 'A');
        }
    }
}
