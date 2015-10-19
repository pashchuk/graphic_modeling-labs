using System.ComponentModel;

namespace lab1
{
    public class MainVindowViewModel : INotifyPropertyChanged
    {
        private double _m = 10, _r = 10;

        public double M
        {
            get { return _m; }
            set
            {
                _m = value;
                OnPropertyChanged(nameof(M));
            }
        }

        public double R
        {
            get { return _r; }
            set
            {
                _r = value;
                OnPropertyChanged(nameof(R));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}