using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1
{
    public class MyFigure : Shape
    {
        protected override Geometry DefiningGeometry
        {
            get
            {
                var figure = new PathFigure();
                var xOffset = ActualWidth/2;
                var yOffset = ActualHeight/2;
                figure.StartPoint = new Point(R + xOffset, yOffset);
                for (int t = 1 ; t < 360; t++)
                {
                    // x = (R-m*R)*cos(m*t)+m*R*cos(t-m*t)
                    // y = (R - m * R) * sin(m * t) + m * R * sin(t - m * t)
                    figure.Segments.Add(new LineSegment(new Point(
                        (R - M*R)*Math.Cos(M*t) + M*R*Math.Cos(t - M*t) + xOffset,
                        -1*((R - M*R)*Math.Sin(M*t) + M*R*Math.Sin(t - M*t)) + yOffset), true));
                }
                figure.IsClosed = figure.IsFilled = false;
                return new PathGeometry(new[] {figure});
            }
        }

        [TypeConverter(typeof(LengthConverter))]
        public double M
        {
            get { return (double) GetValue(MProperty); }
            set { SetValue(MProperty, value); }
        }

        [TypeConverter(typeof(LengthConverter))]
        public double R
        {
            get { return (double)GetValue(RProperty); }
            set { SetValue(RProperty, value); }
        }

        public static readonly DependencyProperty MProperty = DependencyProperty
            .Register(nameof(M), typeof (double), typeof (MyFigure),
                new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty RProperty = DependencyProperty
            .Register(nameof(R), typeof (double), typeof (MyFigure),
                new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.AffectsRender));

    }
}