using GymGenius.Models;
using GymGenius.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GymGenius.Views
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Session session = new Session();
        public Page CurrentPage { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.CurrentPage = new HomePage(this);
            NavigateToPage(CurrentPage);
        }

        public void NavigateToPage(Page page)
        {
            this.CurrentPage = page;
            MainContent.Navigate(page);
        }

        private void ReturnHomeClick(object sender, RoutedEventArgs e)
        {
            bool continueToHome = MessagesBox.ShowYesNoMessageBox("Voulez-vous retourner à l'accueil ?\n\nLa création de séance en cours sera perdue et les exercices choisis seront réinitialisés", "Confirmation");

            if (continueToHome)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
        }
    }
}
