using System.Diagnostics;
using ChessProject.Pieces;

namespace ChessProject;

public class Board
{
    private const string StartingString = ""; //TODO: Enter correct string;
    private IChessPiece?[] _positions = new IChessPiece?[64];
    
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