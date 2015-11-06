using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace lab5
{
    public class MyFigure : lab1.MyFigure
    {
        protected override Geometry DefiningGeometry
        {
            get
            {
                var baseFigure = new Path() {Data = Geometry.Parse("M -10 -10 V 10 H 10 V -10")};
                var figure = new PathFigure();
                var xOffset = ActualWidth / 2;
                var yOffset = ActualHeight / 2;
                figure.StartPoint = new Point(R + xOffset, yOffset);
                var list = new List<Geometry>();
                for (double t = 1; t < 360; t += 1)
                {
                    // x = (R-m*R)*cos(m*t)+m*R*cos(t-m*t)
                    // y = (R - m * R) * sin(m * t) + m * R * sin(t - m * t)
                    var x = (R - M*R)*Math.Cos(M*t) + M*R*Math.Cos(t - M*t) + xOffset;
                    var y = (R - M*R)*Math.Sin(M*t) + M*R*Math.Sin(t - M*t) + yOffset;
                    var halfRadius = FigureRadius/2;
                    list.Add(Geometry.Parse(
                        string.Format("M {0} {1} V {3} H {2} V {1} H {0} M {0} {5} L {4} {3} L {2} {5} L {4} {1} Z",
                            x - halfRadius, y - halfRadius, x + halfRadius, y + halfRadius, x, y)));
                }
                figure.IsClosed = figure.IsFilled = false;
                return new GeometryGroup() {Children = new GeometryCollection(list)};

            }
        }

        public static readonly DependencyProperty FigureRadiusProperty = DependencyProperty.Register(
            "FigureRadius", typeof (double), typeof (MyFigure),
            new FrameworkPropertyMetadata(10.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public double FigureRadius
        {
            get { return (double) GetValue(FigureRadiusProperty); }
            set { SetValue(FigureRadiusProperty, value); }
        }
    }
}