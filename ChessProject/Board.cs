using System.Diagnostics;
using ChessProject.Pieces;

namespace ChessProject;

public class Board
{
    private const string StartingString = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
    private IChessPiece?[] _positions = new IChessPiece?[64];
    public bool WhiteHasNextMove { get; set ; }
    public bool WhiteCanCastleQueenSide { get; set ; }
    public bool WhiteCanCastleKingSide { get; set ; }
    public bool BlackCanCastleQueenSide { get; set ; }
    public bool BlackCanCastleKingSide { get; set ; }
    public int CurrentHalfMoves { get; set ; }
    public int CurrentFullMoves { get; set ; }

    public List<int> ÉnPassantTargetSquares = new ();
    
    public IChessPiece?[] Positions => _positions;

    public Board(string setupString = StartingString)
    {
        SetPosition(setupString);
    }
    public void Move(GameMove move)
    {
        Debug.Assert(_positions[move.From] != null);

        _positions[move.To] = _positions[move.From];
        _positions[move.From] = null;
    }

    private void SetPosition(string positionsString)
    {
        _positions = new IChessPiece[64];
    }
    
}