using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace _10000_Things
{
    public class CircleObject
    {
        public Canvas Root { get; }
        public double Size { get; }

        public CircleObject(double size, Brush color, Random rng)
        {
            Size = size;

            Root = new Canvas
            {
                Width = size,
                Height = size
            };

            // larger outer circle
            Ellipse outer = new Ellipse
            {
                Width = size,
                Height = size,
                Fill = color
            };

            Root.Children.Add(outer);

            // white inner circles aka gaps
            int innerCount = rng.Next(2, 6);

            for (int i = 0; i < innerCount; i++)
            {
                double innerSize = rng.NextDouble() * (size * 0.4) + size * 0.1;

                Ellipse inner = new Ellipse
                {
                    Width = innerSize,
                    Height = innerSize,
                    Fill = Brushes.White
                };

                double x = rng.NextDouble() * (size - innerSize);
                double y = rng.NextDouble() * (size - innerSize);

                Canvas.SetLeft(inner, x);
                Canvas.SetTop(inner, y);

                Root.Children.Add(inner);
            }
        }
    }
}
