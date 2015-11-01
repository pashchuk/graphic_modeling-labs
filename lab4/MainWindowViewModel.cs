namespace lab4
{
    public class MainWindowViewModel: lab1.MainVindowViewModel
    {
        private double _figureRadius = 10.0;

        public double FigureRadius
        {
            get { return _figureRadius; }
            set
            {
                _figureRadius = value;
                OnPropertyChanged(nameof(FigureRadius));
            }
        }
    }
}