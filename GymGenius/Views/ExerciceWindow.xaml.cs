using GymGenius.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GymGenius.Views
{
    public partial class ExerciceWindow : Window
    {
        // Property to store the list of exercises
        public List<AExercise> Exercises { get; set; }

        public ExerciceWindow()
        {
            InitializeComponent();
            InitializePlaceholder();

            // Initialize the list of exercises
            Exercises = new List<AExercise>
            {
                new PushUps(),
                new PullUps(),
                new Dips(),
            };

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
            // Handle checkbox checked event
            // La case à cocher a été cochée, exécutez votre logique ici
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Show();
            Seance seance = new();
            seance.Show();
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Valider que la saisie est un chiffre
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }

            // Limiter la valeur maximale à 5
            if (int.TryParse(numericTextBox.Text + e.Text, out int result) && result > 5)
            {
                e.Handled = true;
            }
        }

        private void numericTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void OnSearch_click(object sender, RoutedEventArgs e)
        {
            // Handle search button click event
        }
    }
}
