using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ChessProject;
using ChessProject.Pieces;

namespace ChessGui;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private BoardState _boardState;
    private Grid draggedGrid;

    public MainWindow()
    {
        InitializeComponent();
        _boardState =
            FENParser.FenStringToBoard(
                "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"); // Create a new board state
        DrawChessBoard(); // Draw the chessboard with pieces
    }

    // Method to draw the chessboard
    private void DrawChessBoard()
    {
        Board.Children.Clear(); // Clear the chessboard grid if needed

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                // Create a Grid for each square to hold both the rectangle (background) and the image (piece)
                var squareGrid = new Grid();
                squareGrid.AllowDrop = true; // Enable drop on squares
                squareGrid.MouseDown += Square_MouseLeftButtonDown;
                squareGrid.Drop += Square_Drop;
                squareGrid.MouseMove += Square_MouseMove;

                // Determine the color of the square (alternating white and black)
                var squareColor = (row + col) % 2 == 0 ? Brushes.White : Brushes.Gray;
                var rectangle = new Rectangle
                {
                    Fill = squareColor
                };

                squareGrid.Tag = (row + col) % 2 == 0;

                // Add the rectangle (background square) to the Grid
                squareGrid.Children.Add(rectangle);

                // Check if there is a piece at this position
                var piece = _boardState.Positions[row * 8 + col];
                if (piece != null)
                {
                    var pieceImage = new Image
                    {
                        Source = new BitmapImage(new Uri(piece.ImageSource())),
                        Stretch = Stretch.Uniform, // Keep aspect ratio
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    // Store the piece's row and column
                    pieceImage.Tag = piece;

                    // Add the image (chess piece) to the Grid, it will be layered on top of the rectangle
                    squareGrid.Children.Add(pieceImage);
                }

                // Add the square grid (with both the square and piece, if any) to the chessboard
                Board.Children.Add(squareGrid);
            }
        }
    }

    private void Square_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (sender is Grid grid)
        {
            // Start dragging the piece (or square)
            draggedGrid = grid;
            DragDrop.DoDragDrop(grid, grid, DragDropEffects.Move);
        }
    }

    private void Square_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Released)
            return;

        // If the mouse is not over a square, we don't want to start a drag operation
        if (draggedGrid == null)
            return;

        // Start the drag operation
        DragDrop.DoDragDrop(draggedGrid, draggedGrid, DragDropEffects.Move);
    }

    private void Square_Drop(object sender, DragEventArgs e)
    {
        if (sender is Grid targetGrid && draggedGrid != null)
        {
            if(draggedGrid == targetGrid)
                return;
            
            // You can now handle the drop event
            // E.g., you can change the visual representation of the dragged piece
            // For simplicity, we're just moving the original piece here
            foreach (UIElement thing in draggedGrid.Children)
            {
                if (thing is not Image img) continue;
                var pieceImage = new Image
                {
                    Source = new BitmapImage(new Uri(((IChessPiece)(img.Tag)).ImageSource())),
                    Stretch = Stretch.Uniform, // Keep aspect ratio
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
                pieceImage.Tag = img.Tag;
                var targetRectangle = new Rectangle();
                targetRectangle.Fill = (bool)targetGrid.Tag ? Brushes.White : Brushes.Gray;
                targetGrid.Children.Clear();
                targetGrid.Children.Add(targetRectangle);
                targetGrid.Children.Add(pieceImage);
            }

            draggedGrid.Children.Clear();
            draggedGrid.Children.Add(new Rectangle
            {
                Fill = (bool)draggedGrid.Tag ? Brushes.White : Brushes.Gray 
            });
        }
    }
}