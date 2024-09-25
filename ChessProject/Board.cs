using System.Diagnostics;
using ChessProject.Pieces;

namespace ChessProject;

public class Board
{
    private const string StartingString = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
    public IChessPiece?[] Positions = new IChessPiece?[64];
    public bool WhiteHasNextMove { get; set ; }
    public bool WhiteCanCastleQueenSide { get; set ; }
    public bool WhiteCanCastleKingSide { get; set ; }
    public bool BlackCanCastleQueenSide { get; set ; }
    public bool BlackCanCastleKingSide { get; set ; }
    public int CurrentHalfMoves { get; set ; }
    public int CurrentFullMoves { get; set ; }

    public List<int> ÉnPassantTargetSquares = new ();
    

    public Board(string setupString = StartingString)
    {
        SetPosition(setupString);
    }
    public void Move(GameMove move)
    {
        Debug.Assert(Positions[move.From] != null);

        Positions[move.To] = Positions[move.From];
        Positions[move.From] = null;
    }

    private void SetPosition(string positionsString)
    {
        Positions = new IChessPiece[64];
    }
    
}