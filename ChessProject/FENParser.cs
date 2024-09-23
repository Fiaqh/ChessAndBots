using ChessProject.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessProject
{
    public static class FENParser
    {
        public static Board ParseFenString(string FenString)
        {
            var pieces = new IChessPiece[64];
            var builder = new StringBuilder(FenString);

            var index = 0;
            while (index < 64)
            {
                
            }
            return new Board();
        }

        private static int GoToNext8(int number)
        {
            return 8 - (number % 8) + number; 
        }

        private static IChessPiece GetChessPieceFromSymbol(char symbol)
        {
            switch (symbol)
            {
                case 'p':
                    return new Pawn(false);
                    break;
                case 'P':
                    return new Pawn(true);
                    break;
                case 'r':
                    return new Rook(false);
                    break;
                case 'R':
                    return new Rook(true);
                    break;
                case 'n':
                    return new Knight(false);
                    break;
                case 'N':
                    return new Knight(true);
                    break;
                case 'b':
                    return new Bishop(false);
                    break;
                case 'B':
                    return new Bishop(true);
                    break;
                case 'q':
                    return new Queen(false);
                    break;
                case 'Q':
                    return new Queen(true);
                    break;
                case 'k':
                    return new King(false);
                    break;
                case 'K':
                    return new King(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
