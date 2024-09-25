using ChessProject.Pieces;
using System.Diagnostics;

namespace ChessProject
{
    public static class FENParser
    {
        public static Board FenStringToBoard(string fenString)
        {
            var pieces = new List<IChessPiece>();
            var splitFenString = fenString.Split(' ');
            var isWhitesTurn = false;
            var index = 0;
            var board = new Board();

            //placement of pieces
            foreach (var character in splitFenString[0])
            {
                index++;
                if (System.Char.IsDigit(character))
                {
                    pieces.AddRange(new IChessPiece[character]);
                }
                else if (character == '/')
                {
                    //ignore
                }
                else
                {
                    pieces.Add(GetChessPieceFromCharacter(character));
                }
            }

            Debug.Assert(pieces.Count == 64);


            //Turn decider
            board.WhiteHasNextMove = splitFenString[1] == "w";

            //Castling
            foreach (char character in splitFenString[2])
            {
                if (character == '-')
                    break;
                else if (character == 'K')
                {
                    board.WhiteCanCastleKingSide = true;
                }
                else if (character == 'Q')
                {
                    board.WhiteCanCastleQueenSide = true;
                }
                else if (character == 'k')
                {
                    board.BlackCanCastleKingSide = true;
                }
                else if (character == 'q')
                {
                    board.BlackCanCastleQueenSide = true;
                }
            }

            // En passant target squares
            var enPassantSquaers = new List<int>();
            for (var i = 0; i+1 < splitFenString[2].Length; i++)
            {
                var (file, rank) = (splitFenString[2][i], int.Parse(splitFenString[2][++i].ToString()));
                enPassantSquaers.Add(AlgebraicNotationToIndex(file, rank));
            }
            board.ÉnPassantTargetSquares = enPassantSquaers;

            //Half move clock
            board.CurrentHalfMoves = int.Parse(splitFenString[3].ToString());

            //Full moves
            board.CurrentFullMoves = int.Parse(splitFenString[4].ToString());

            return board;

        }

        private static int AlgebraicNotationToIndex(char file, int rank)
        {
            switch (file)
            {
                case 'a': return 1 * rank - 1;
                case 'b': return 2 * rank - 1;
                case 'c': return 3 * rank - 1;
                case 'd': return 4 * rank - 1;
                case 'e': return 5 * rank - 1;
                case 'f': return 6 * rank - 1;
                case 'g': return 7 * rank - 1;
                case 'h': return 8 * rank - 1;
                default: throw new ArgumentOutOfRangeException();
            }
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

        private static int GoToNext8(int number)
        {
            return 8 - (number % 8) + number;
        }

    }
}
