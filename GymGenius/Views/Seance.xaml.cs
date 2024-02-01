using GymGenius.Models;
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
using GymGenius.Utilities;
using GymGenius.Controllers;

namespace GymGenius.Views
{
    /// <summary>
    /// Logique d'interaction pour Seance.xaml
    /// </summary>
    public partial class Seance : Window
    {
        public List<AExercise> Exercises { get; set; }
        public Session Session { get; set; }

        public Seance(Session session)
        {
            InitializeComponent();
            InitializePlaceholder();

            this.Session = session;
            Exercises = session.exercises;

            // Set the DataContext to this window so that bindings work
            DataContext = this;
        }

        private void InitializePlaceholder()
        {
            ShowPlaceholder();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            HidePlaceholder();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchbar.Text))
            {
                ShowPlaceholder();
            }
        }

        private void ShowPlaceholder()
        {
            searchbar.Text = "Rechercher un exercice en particulier";
            searchbar.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#25322C"));
            searchbar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6D887B"));
        }

        private void HidePlaceholder()
        {
            if (searchbar.Text == "Rechercher un exercice en particulier")
            {
                searchbar.Text = string.Empty;
                searchbar.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#25322C"));
                searchbar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6D887B"));
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // La case à cocher a été cochée, exécutez votre logique ici
        }
        public int NumericalValue { get; set; }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            SessionWindow sessionWindow = new SessionWindow(this.Session);
            sessionWindow.Show();
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of ICSUtils with fake variables
            DateTime date = DateTime.Now.AddDays(3); // ERROR: date is always null
            if (Session.date != null)
            {
                date = (DateTime)Session.date;
            }

            ICSUtils ics = new ICSUtils(
                "GymGenius",
                date,
                this.Exercises
            );

            // Call the ExportICS method
            ics.ExportICS();
        }
    }
}
