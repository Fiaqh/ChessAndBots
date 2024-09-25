using ChessProject.Pieces;

namespace ChessProject;

public static class GameJudge
{
    public static bool VerifyMove(IChessPiece?[] positions, GameMove move)
    {
        var toPiece = positions[move.To];
        switch (positions[move.From])
        {
            case Pawn:
                return CanPawnMove(positions, move);
                break;
            case Rook:
                return CanRookMove(positions, move);
                break;
            case King:
                return CanKingMove(positions, move);
                break;
            case Queen:
                return CanQueenMove(positions, move);
                break;
            case Knight:
                return CanKnightMove(positions, move);
                break;
            case Bishop:
                return CanBishopMove(positions, move);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static bool CanPawnMove(IChessPiece?[] positions, GameMove move)
    {
        throw new NotImplementedException();
    }

    private static bool CanRookMove(IChessPiece?[] positions, GameMove move)
    {
        throw new NotImplementedException();
    }

    private static List<int> GetValidRookMoves(IChessPiece?[] positions, int startPosition, bool isWhiteMoving)
    {
        var moves = new List<int>();
        // move right
        var moveRightIndex = 1;
        while (moveRightIndex + startPosition < 64 && (moveRightIndex + startPosition) % 8 != 0 &&
               (positions[startPosition + moveRightIndex] == null ||
                positions[startPosition + moveRightIndex]!.IsWhite() != isWhiteMoving))
        {
            
            if(positions[startPosition + moveRightIndex] != null && positions[startPosition + moveRightIndex]!.IsWhite() != isWhiteMoving)
            {
                moves.Add(moveRightIndex + startPosition);
                break;
            }

            if (positions[startPosition + moveRightIndex] != null &&
                positions[startPosition + moveRightIndex]!.IsWhite() == isWhiteMoving)
                break;
            
            moveRightIndex++;
        }
        return moves;
    }

    private static bool CanKingMove(IChessPiece?[] positions, GameMove move)
    {
        throw new NotImplementedException();
    }

    private static bool CanKnightMove(IChessPiece?[] positions, GameMove move)
    {
        throw new NotImplementedException();
    }

    private static bool CanQueenMove(IChessPiece?[] positions, GameMove move)
    {
        throw new NotImplementedException();
    }

    private static bool CanBishopMove(IChessPiece?[] positions, GameMove move)
    {
        throw new NotImplementedException();
    }
}