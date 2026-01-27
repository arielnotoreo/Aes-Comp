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

    public enum ArcaneColor
    {
        VanillaIce = 0xeec3e9,
        CanCan = 0xd99fad,
        Viola = 0xbc7ab3,
        DeepBlush = 0xe88194,
        Surf = 0xbbddc3,
        Nepal = 0x91b0c5,
        KashmirBlue = 0x54799b,
        SanJuan = 0x354b6d,
        Zambezi = 0x67515d,
    }

    public partial class MainWindow : Window
    {
        private const int MaxArcanes = 10000;
        private const int VisibleArcanes = 1000;
        private const int RemovalRadius = 500;

        private readonly DispatcherTimer timer;
        private readonly List<CircleObject> circles = new();
        private readonly Random rng = new Random();

        private int counter = 0;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(5)
            };

            timer.Tick += DrawCircle;
            timer.Start();
        }

        private void DrawCircle(object? sender, EventArgs e)
        {
            if (counter >= MaxArcanes)
                counter = 0;

            double size = RandomCircleSize();
            Brush color = RandomBrush();

            CircleObject circle = new CircleObject(size, color, rng);

            double x = rng.NextDouble() * (Canvas.ActualWidth - size);
            double y = rng.NextDouble() * (Canvas.ActualHeight - size);

            Canvas.SetLeft(circle.Root, x);
            Canvas.SetTop(circle.Root, y);

            Canvas.Children.Add(circle.Root);
            circles.Add(circle);

            if (circles.Count > VisibleArcanes)
            {
                int centerIndex = rng.Next(0, circles.Count);

                int start = Math.Max(0, centerIndex - RemovalRadius);
                int end = Math.Min(circles.Count - 1, centerIndex + RemovalRadius);

                for (int i = end; i >= start; i--)
                {
                    Canvas.Children.Remove(circles[i].Root);
                    circles.RemoveAt(i);
                }
            }

            counter++;
        }

        private double RandomCircleSize()
        {
            return rng.NextDouble() * 60 + 20; // 20–80 px
        }

        private SolidColorBrush RandomBrush()
        {
            Array values = Enum.GetValues(typeof(ArcaneColor));
            ArcaneColor chosen = (ArcaneColor)values.GetValue(rng.Next(values.Length))!;

            int hex = (int)chosen;

            byte r = (byte)((hex >> 16) & 0xFF);
            byte g = (byte)((hex >> 8) & 0xFF);
            byte b = (byte)(hex & 0xFF);

            return new SolidColorBrush(Color.FromRgb(r, g, b));
        }

    }
}