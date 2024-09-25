namespace ChessProject;

public class Program
{
    static void Main()
    {
        var board = FENParser.FenStringToBoard("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
    }
}