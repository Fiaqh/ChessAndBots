using ChessProject.Pieces;

namespace ChessProject;

public static class AggressionMoveEngine
{
    public static List<int> GetAggressionPieceMoves(BoardState boardState, int piecePosition)
    {
        var positions = boardState.Positions;
        var piece = boardState.Positions[piecePosition];
        if (piece == null) return new List<int>();
        switch (piece)
        {
            case Pawn:
                return PawnMoves(boardState, piecePosition);
                break;
            case Rook:
                return RookMoves(boardState, piecePosition);
                break;
            case King:
                return KingMoves(boardState, piecePosition);
                break;
            case Queen:
                return QueenMoves(boardState, piecePosition);
                break;
            case Knight:
                return KnightMoves(boardState, piecePosition);
                break;
            case Bishop:
                return BishopMoves(boardState, piecePosition);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static List<int> PawnMoves(BoardState boardState, int piecePosition)
    {
        throw new NotImplementedException();
    }


    private static List<int> RookMoves(BoardState boardState, int piecePosition)
    {
        var moves = new List<int>();

        var piece = boardState.Positions[piecePosition];
        var isWhite = piece!.IsWhite();
        // move right
        var moveRightPosition = piecePosition + 1;
        while (moveRightPosition % 8 != 0)
        {
            if (TryAddCapture(boardState, moveRightPosition, isWhite, moves)) break;

            moveRightPosition++;
        }

        //Move left
        var moveLeftPosition = piecePosition - 1;
        while (moveLeftPosition % 8 != 7)
        {
            if (TryAddCapture(boardState, moveLeftPosition, isWhite, moves)) break;

            moveLeftPosition--;
        }

        //Move up
        var moveUpPosition = piecePosition - 8;
        while (moveUpPosition >= 0)
        {
            if (TryAddCapture(boardState, moveUpPosition, isWhite, moves)) break;

            moveUpPosition -= 8;
        }

        //Move down
        var moveDownPosition = piecePosition + 8;
        while (moveDownPosition < 64)
        {
            if (TryAddCapture(boardState, moveDownPosition, isWhite, moves)) break;


            moveDownPosition += 8;
        }

        return moves;
    }

    private static bool TryAddCapture(BoardState boardState, int piecePosition, bool isWhite, List<int> moves)
    {
        if (boardState.Positions[piecePosition] != null && boardState.Positions[piecePosition]!.IsWhite() != isWhite)
        {
            moves.Add(piecePosition);
            return true;
        }

        if (boardState.Positions[piecePosition] != null &&
            boardState.Positions[piecePosition]!.IsWhite() == isWhite)
            return true;

        moves.Add(piecePosition);
        return false;
    }

    private static List<int> KingMoves(BoardState boardState, int piecePosition)
    {
        throw new NotImplementedException();
    }

    private static List<int> KnightMoves(BoardState boardState, int piecePosition)
    {
        var moves = new List<int>();
        var piece = boardState.Positions[piecePosition];
        var isWhite = piece!.IsWhite();

        //Up Right
        var upRight = piecePosition - 15;
        if (upRight >= 0 && upRight % 8 != 0) TryAddCapture(boardState, upRight, isWhite, moves);

        //Up Left
        var upLeft = piecePosition - 17;
        if (upLeft >= 0 && upLeft % 8 != 7) TryAddCapture(boardState, upLeft, isWhite, moves);

        //Down Right
        var downRight = piecePosition + 17;
        if (downRight < 64 && downRight % 8 != 0) TryAddCapture(boardState, downRight, isWhite, moves);

        //Down Left
        var downLeft = piecePosition + 15;
        if (downLeft < 64 && downLeft % 8 != 7) TryAddCapture(boardState, downLeft, isWhite, moves);

        // Left up
        var leftUp = piecePosition - 10;
        if (leftUp >= 0 && leftUp % 8 <= piecePosition % 8) TryAddCapture(boardState, leftUp, isWhite, moves);

        //Left down
        var leftDown = piecePosition + 6;
        if (leftDown < 64 && leftDown % 8 <= piecePosition % 8) TryAddCapture(boardState, leftDown, isWhite, moves);

        //Right up
        var rightUp = piecePosition - 6;
        if (rightUp >= 0 && rightUp % 8 >= piecePosition % 8) TryAddCapture(boardState, rightUp, isWhite, moves);

        //Right down
        var rightDown = piecePosition + 10;
        if (rightDown < 64 && rightDown % 8 >= piecePosition % 8) TryAddCapture(boardState, rightDown, isWhite, moves);

        return moves;
    }

    private static List<int> QueenMoves(BoardState boardState, int piecePosition)
    {
        var moves = BishopMoves(boardState, piecePosition);
        moves.AddRange(RookMoves(boardState, piecePosition));
        return moves;
    }

    private static List<int> BishopMoves(BoardState boardState, int piecePosition)
    {
        var moves = new List<int>();
        var piece = boardState.Positions[piecePosition];
        var isWhite = piece!.IsWhite();

        //DiagonalUpRight
        var diagonalUpright = piecePosition - 7;
        while (diagonalUpright % 8 != 0 && diagonalUpright >= 0)
        {
            if (TryAddCapture(boardState, diagonalUpright, isWhite, moves)) break;
            diagonalUpright -= 7;
        }

        var diagonalUpLeft = piecePosition - 9;
        while (diagonalUpLeft % 8 != 7 && diagonalUpLeft >= 0)
        {
            if (TryAddCapture(boardState, diagonalUpLeft, isWhite, moves)) break;
            diagonalUpLeft -= 9;
        }

        var diagonalDownRight = piecePosition + 9;
        while (diagonalDownRight % 8 != 0 && diagonalDownRight < 64)
        {
            if (TryAddCapture(boardState, diagonalDownRight, isWhite, moves)) break;
            diagonalDownRight += 9;
        }

        var diagonalDownLeft = piecePosition + 7;
        while (diagonalDownLeft % 8 != 7 && diagonalDownLeft < 64)
        {
            if (TryAddCapture(boardState, diagonalDownLeft, isWhite, moves)) break;
            diagonalDownLeft += 7;
        }

        return moves;
    }

    private static bool IsCheckOnBoard(BoardState boardState, bool isWhiteTurn)
    {
        return true;
    }
}