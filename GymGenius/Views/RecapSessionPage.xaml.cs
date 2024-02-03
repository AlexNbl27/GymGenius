using GymGenius.Models;
using GymGenius.Utilities;
using System.Windows;
using System.Windows.Controls;

namespace GymGenius.Views
{
    public partial class RecapSessionPage : Page
    {
        private readonly MainWindow mainWindow;

        public List<AExercise> Exercises { get; set; } // Binnded variable

        public RecapSessionPage(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            InitializeComponent();
            Exercises = mainWindow.session.exercises;

            // Set the DataContext to this window so that bindings work
            DataContext = this;
        }

        // ===== CLICK FUNCTIONS ===== //

        public void SessionButtonClick(object sender, RoutedEventArgs e)
        {
            mainWindow.NavigateToPage(new SessionPage(mainWindow));
        }

        private void ExportButtonClick(object sender, RoutedEventArgs e)
        {
            ICSUtils ics = new(mainWindow.session);
            ics.ExportICS();
        }
    }
}
