using PFAB.TicTacToe.Engine;
using static PFAB.TicTacToe.Runner.BoardPrinter.TablePrintingCharacters;

namespace PFAB.TicTacToe.Runner;

internal class BoardPrinter
{
    public static void Print(IBoard board)
    {
        var squares = board.GetSquares();

        PrintHeader(squares[0].Length);

        for (var y = 0; y < squares.Length; y++)
        {
            PrintRow(y, squares[y]);
        }

        PrintFooter(squares[0].Length);
    }

    private static void PrintHeader(int length)
    {
        var header = Enumerable
            .Range(0, length)
            .Select(i => (i + 1).ToString()).ToList();
        Console.WriteLine(
            $"{TopLeftCorner}{Spacing}{string.Join(null, Enumerable.Repeat($"{T}{Spacing}", header.Count))}{TopRightCorner}");
        Console.WriteLine($"  {Divider} {Vertical} {string.Join($" {Vertical} ", header)} {Vertical}");
    }

    private static void PrintFooter(int length)
    {
        var verticalLine = new string(Horizontal, Spacing.Length);
        Console.WriteLine(
            $"{BottomLeftCorner}{verticalLine}{string.Join(null, Enumerable.Repeat($"{ReverseT}{verticalLine}", length))}{BottomRightCorner}");
    }

    private static void PrintRow(int rowIndex, Square[] row)
    {
        var verticalLine = new string(Horizontal, Spacing.Length);
        Console.WriteLine(
            $"{LeftT}{verticalLine}{string.Join(null, Enumerable.Repeat($"{Cross}{verticalLine}", row.Length))}{RightT}");
        var printableRow = string.Join($" {Vertical} ", row.Select(c => c.IsOccupied ? c.Symbol : ' '));

        Console.Write($"  {(char)('A' + rowIndex)} {Vertical}");
        for (var i = 0; i < row.Length; i++)
        {
            var square = row[i];
            if (square.IsHighlighted)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            Console.Write($" {(square.IsOccupied ? square.Symbol : ' ')} ");
            Console.ResetColor();
            Console.Write($"{Vertical}");
        }
        Console.WriteLine();
        //Console.WriteLine($"  {(char)('A' + rowIndex)} {Vertical} {printableRow} {Vertical}");
    }

    internal static class TablePrintingCharacters
    {
        public static readonly char TopLeftCorner = '┌';
        public static readonly char TopRightCorner = '┐';
        public static readonly char BottomLeftCorner = '└';
        public static readonly char BottomRightCorner = '┘';
        public static readonly char Vertical = '│';
        public static readonly char Horizontal = '─';
        public static readonly char Cross = '┼';
        public static readonly char T = '┬';
        public static readonly char ReverseT = '┴';
        public static readonly char LeftT = '├';
        public static readonly char RightT = '┤';
        public static readonly char Divider = '\\';
        public static readonly string Spacing = new (' ', 3);
    }
}
