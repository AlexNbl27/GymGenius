using GymGenius.Models;
using GymGenius.Utilities;
using System.Windows;
using System.Windows.Controls;

namespace GymGenius.Views
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Session session = new();
        public Page CurrentPage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            CurrentPage = new HomePage(this);
            NavigateToPage(CurrentPage);
        }

        public void NavigateToPage(Page page)
        {
            CurrentPage = page;
            MainContent.Navigate(page);
        }

        private void ReturnHomeClick(object sender, RoutedEventArgs e)
        {
            bool continueToHome = MessagesBox.ShowYesNoMessageBox("Voulez-vous retourner à l'accueil ?\n\nLa création de séance en cours sera perdue et les exercices choisis seront réinitialisés", "Confirmation");

            if (continueToHome)
            {
                MainWindow mainWindow = new();
                mainWindow.Show();
                Close();
            }
        }
    }
}
