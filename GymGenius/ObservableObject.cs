using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1
{
    internal class ObservableObject : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}