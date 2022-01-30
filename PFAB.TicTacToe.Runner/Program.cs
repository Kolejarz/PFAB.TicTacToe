using PFAB.TicTacToe.Engine;
using PFAB.TicTacToe.Runner;

var gameInProgress = true;

var consoleMoveReader = new ConsoleMoveReader();
var g = new GameMaster(new GenericWinnerLookup(4));
BoardPrinter.Print(g.Board);

// main game loop
while (gameInProgress)
{
    Console.Clear();
    BoardPrinter.Print(g.Board);

    var move = consoleMoveReader.GetCoordinates();
    g.MakeMove(move);

    var result = g.GameResult();
    if (string.IsNullOrEmpty(result)) continue;

    Console.WriteLine($"Result is {result}");
    gameInProgress = false;
}