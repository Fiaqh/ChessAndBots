using ChessProject.Pieces;

namespace ChessProject;

public static class FENParser
{
    public static BoardState FenStringToBoard(string fenString)
    {
        var pieces = new List<IChessPiece>();
        var splitFenString = fenString.Split(' ');
        var isWhitesTurn = false;
        var board = new BoardState();

        //placement of pieces
        foreach (var character in splitFenString[0])
            if (char.IsDigit(character))
            {
                pieces.AddRange(new IChessPiece[int.Parse(character.ToString())]);
            }
            else if (character == '/')
            {
                //ignore
            }
            else
            {
                pieces.Add(GetChessPieceFromCharacter(character));
            }

        board.Positions = pieces.ToArray();


        //Turn decider
        board.WhiteHasNextMove = splitFenString[1] == "w";

        //Castling
        foreach (var character in splitFenString[2])
            if (character == '-')
                break;
            else if (character == 'K')
                board.WhiteCanCastleKingSide = true;
            else if (character == 'Q')
                board.WhiteCanCastleQueenSide = true;
            else if (character == 'k')
                board.BlackCanCastleKingSide = true;
            else if (character == 'q') board.BlackCanCastleQueenSide = true;

        // En passant target squares
        var enPassantSquares = new List<int>();
        if (splitFenString[3][0] != '-')
        {
            for (var i = 0; i + 1 < splitFenString[3].Length; i++)
            {
                var (file, rank) = (splitFenString[3][i], int.Parse(splitFenString[3][++i].ToString()));
                enPassantSquares.Add(AlgebraicNotationToIndex(file, rank));
            }
        }

        board.ÉnPassantTargetSquares = enPassantSquares;

        //Half move clock
        board.CurrentHalfMoves = int.Parse(splitFenString[4]);

        //Full moves
        board.CurrentFullMoves = int.Parse(splitFenString[5]);

        return board;
    }

    public static int AlgebraicNotationToIndex(string input)
    {
        if(input.Length != 2)
            return -1;

        return AlgebraicNotationToIndex(input[0], input[1]);
    }

    private static int AlgebraicNotationToIndex(char file, int rank)
    {
        if (file < 'a' || file > 'h' || rank < 1 || rank > 8)
        {
            throw new ArgumentOutOfRangeException();
        }

        int fileIndex = file - 'a';          // 'a' gives 0, 'b' gives 1, ..., 'h' gives 7
        int rankIndex = 8 - rank;            // Rank 8 gives 0, rank 7 gives 1, ..., rank 1 gives 7

        return rankIndex * 8 + fileIndex;    // Convert to 0-based index
    }

    private static IChessPiece GetChessPieceFromCharacter(char character)
    {
        switch (character)
        {
            case 'p':
                return new Pawn(false);
            case 'P':
                return new Pawn(true);
            case 'r':
                return new Rook(false);
            case 'R':
                return new Rook(true);
            case 'n':
                return new Knight(false);
            case 'N':
                return new Knight(true);
            case 'b':
                return new Bishop(false);
            case 'B':
                return new Bishop(true);
            case 'q':
                return new Queen(false);
            case 'Q':
                return new Queen(true);
            case 'k':
                return new King(false);
            case 'K':
                return new King(true);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}