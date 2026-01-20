using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace _10000_Things
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MaxSquares = 10000;
        private const int VisibleSquares = 1000;
        private const int SquareSize = 20;

        private readonly DispatcherTimer timer;
        private readonly Queue<Rectangle> squares = new();
        private readonly Random rng = new Random();

        private int counter = 0;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(5)
            };

            timer.Tick += DrawSquare;
            timer.Start();
        }

        private void DrawSquare(object? sender, EventArgs e)
        {
            if (counter >= MaxSquares)
            {
                counter = 0;
            }

            Rectangle rect = new Rectangle
            {
                Width = SquareSize,
                Height = SquareSize,
                Fill = Brushes.Pink
            };

            double x = rng.NextDouble() * (Canvas.ActualWidth - SquareSize);
            double y = rng.NextDouble() * (Canvas.ActualHeight - SquareSize);

            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);

            Canvas.Children.Add(rect);
            squares.Enqueue(rect);

            if (squares.Count > VisibleSquares)
            {
                Rectangle? old = squares.Dequeue();
                Canvas.Children.Remove(old);
            }

            counter++;
        }
    }
}