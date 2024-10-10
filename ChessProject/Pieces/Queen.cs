namespace ChessProject.Pieces;

public readonly record struct Queen : IChessPiece
{
    private readonly bool _isWhite;

    public Queen(bool isWhite)
    {
        _isWhite = isWhite;
    }

    public bool IsWhite()
    {
        return _isWhite;
    }
    
    public string ImageSource () => _isWhite ? "C:/Repos/ChessAndBots/ChessProject/Pieces/LightQueen.jpg" : "C:/Repos/ChessAndBots/ChessProject/Pieces/DarkQueen.jpg";

}