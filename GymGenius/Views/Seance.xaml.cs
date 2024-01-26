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
    /// Logique d'interaction pour Seance.xaml
    /// </summary>
    public partial class Seance : Window
    {
        public Seance()
        {
            InitializeComponent();
            InitializePlaceholder();
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
            searchbar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#33443C"));
        }

        private void HidePlaceholder()
        {
            if (searchbar.Text == "Rechercher un exercice en particulier")
            {
                searchbar.Text = string.Empty;
                searchbar.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#25322C"));
                searchbar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#33443C"));
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // La case à cocher a été cochée, exécutez votre logique ici
        }
        public int NumericalValue { get; set; }

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

    }
}
