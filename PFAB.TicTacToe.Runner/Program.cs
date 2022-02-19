using PFAB.TicTacToe.Engine;
using PFAB.TicTacToe.Runner;
using PFAB.TicTacToe.Runner.AI;

var x = 0;
var o = 0;
var draw = 0;

do
{
    //Console.Clear();

    var consoleMoveReader = new ConsoleMoveReader();
    var xMoveGenerator = new RandomAi();
    var oMoveGenerator = new FindsWinningAndLosingMovesAi(4, 'X');
    var g = new GameMaster(new GenericWinnerLookup(4));
    //BoardPrinter.Print(g.Board);

    // main game loop
    while (true)
    {
        //Console.SetCursorPosition(0, 0);
        //BoardPrinter.Print(g.Board);
        //Console.ReadKey(true);
        //Thread.Sleep(300);

        var move = g.CurrentPlayer == 'X'
            ? xMoveGenerator.GetCoordinates(g.Board, g.CurrentPlayer)
            : oMoveGenerator.GetCoordinates(g.Board, g.CurrentPlayer);
        //var move = consoleMoveReader.GetCoordinates(g.Board, g.CurrentPlayer);
        g.MakeMove(move);

        var result = g.GameResult();
        if (string.IsNullOrEmpty(result)) continue;

        if (result == "X") x++;
        if (result == "O") o++;
        if (result == "draw") draw++;
        //Console.Clear();
        //BoardPrinter.Print(g.Board);
        //Console.WriteLine($"Result is {result}");
        Thread.Sleep(100);
        if ((x + o) % 10 == 0) Console.WriteLine($"X: {x} | O: {o} | Draw: {draw}");
        break;
    }
} while (x + o < 300); //while(Console.ReadKey().Key != ConsoleKey.Escape);