namespace PFAB.TicTacToe.Engine;

public record Square(bool IsOccupied, char Symbol, bool IsHighlighted = false);