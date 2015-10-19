using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1
{
    /// <summary>
    /// Interaction logic for FigureControl.xaml
    /// </summary>
    public partial class FigureControl : UserControl
    {
        public FigureControl()
        {
            InitializeComponent();
        }

        public string FigureName
        {
            get { return (string) GetValue(FigureNameProperty); }
            set { SetValue(FigureNameProperty, value); }
        }

        public static readonly DependencyProperty FigureNameProperty = DependencyProperty.Register(
            "FigureName", typeof (string), typeof (FigureControl), null);

        public static readonly DependencyProperty DrawingShapeProperty = DependencyProperty.Register(
            "DrawingShape", typeof (Shape), typeof (FigureControl), new PropertyMetadata(default(Shape)));

        public Shape DrawingShape
        {
            get { return (Shape) GetValue(DrawingShapeProperty); }
            set { SetValue(DrawingShapeProperty, value); }
        }
    }
}
