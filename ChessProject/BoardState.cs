using System.Diagnostics;
using ChessProject.Pieces;

namespace ChessProject;

/// <summary>
/// #############################
/// 8 # 00 01 02 03 04 05 06 07 #
/// 7 # 08 09 10 11 12 13 14 15 #
/// 6 # 16 17 18 19 20 21 22 23 #
/// 5 # 24 25 26 27 28 29 30 31 #
/// 4 # 32 33 34 35 36 37 38 39 #
/// 3 # 40 41 42 43 44 45 46 47 #
/// 2 # 48 49 50 51 52 53 54 55 #
/// 1 # 56 57 58 59 60 61 62 63 #
/// #############################
/// ### a  b  c  d  e  f  g  h
/// </summary>

public record BoardState
{
    public List<int> EnPassantTargetSquares = new();
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
        /* for (var i = 0; i < 64; i++)
             if (Positions[i].IsWhite() == !isWhiteInCheck)
                 AggressionMoveEngine.GetAggressionPieceMoves(this, i);*/

        return true;
    }

    private int GetKingPosition(bool isWhiteKing)
    {
        for (var i = 0; i < 64; i++)
            if (Positions[i] is King king && king.IsWhite() == IsWhiteChecked)
                return i;

        return -1;
    }
}