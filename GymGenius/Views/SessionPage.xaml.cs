using System.Windows;
using System.Windows.Controls;

namespace GymGenius.Views
{
    public partial class SessionPage : Page
    {
        private readonly SessionPageViewModel viewModel;

        public SessionPage(MainWindow mainWindow)
        {
            InitializeComponent();
            viewModel = new SessionPageViewModel(mainWindow);
            DataContext = viewModel;
        }

        // ==== CLICK FUNCTIONS ===== //

        private void StopButton(object sender, RoutedEventArgs e) { viewModel.EndSession(); }

        private void NextButton(object sender, RoutedEventArgs e) { viewModel.NextButton(); }
    }
}
