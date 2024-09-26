using System.Diagnostics;
using ChessProject.Pieces;

namespace ChessProject;

public record BoardState
{
    public List<int> ÉnPassantTargetSquares = new();
    public IChessPiece?[] Positions = new IChessPiece?[64];

    public bool WhiteHasNextMove { get; set; }
    public bool WhiteCanCastleQueenSide { get; set; }
    public bool WhiteCanCastleKingSide { get; set; }
    public bool BlackCanCastleQueenSide { get; set; }
    public bool BlackCanCastleKingSide { get; set; }
    public int CurrentHalfMoves { get; set; }
    public int CurrentFullMoves { get; set; }

    public bool IsWhiteChecked => IsCheckOnBoard(true);
    public bool IsBlackChecked => IsCheckOnBoard(false);

    public BoardState Move(GameMove move)
    {
        Debug.Assert(Positions[move.From] != null);

        Positions[move.To] = Positions[move.From];
        Positions[move.From] = null;
        return this;
    }

    private bool IsCheckOnBoard(bool isWhiteInCheck)
    {
        for (var i = 0; i < 64; i++)
            if (Positions[i].IsWhite() == !isWhiteInCheck)
                AggressionMoveEngine.GetAggressionPieceMoves(this, i);
    }

    private int GetKingPosition(bool isWhiteKing)
    {
        for (var i = 0; i < 64; i++)
            if (Positions[i] is King king && king.IsWhite() == IsWhiteChecked)
                return i;

        return -1;
    }
}