using GymGenius.Models;
using GymGenius.Utilities;
using System.Windows;

namespace GymGenius.Views
{
    public partial class RecapSessionWindow : Window
    {
        public Session Session { get; set; }
        public List<AExercise> Exercises { get; set; } // Binnded variable

        public RecapSessionWindow(Session session)
        {
            InitializeComponent();

            this.Session = session;
            Exercises = session.exercises;

            // Set the DataContext to this window so that bindings work
            DataContext = this;
        }

        // ===== CLICK FUNCTIONS ===== //

        public void SessionButtonClick(object sender, RoutedEventArgs e)
        {
            SessionWindow sessionWindow = new SessionWindow(this.Session);
            sessionWindow.Show();
        }

        private void ExportButtonClick(object sender, RoutedEventArgs e)
        {
            ICSUtils ics = new ICSUtils(this.Session);
            ics.ExportICS();
        }
    }
}
