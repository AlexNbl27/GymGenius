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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GymGenius.Views
{
    /// <summary>
    /// Logique d'interaction pour ExerciceWindow.xaml
    /// </summary>
    public partial class ExerciceWindow : Window
    {
        public ExerciceWindow()
        {
            InitializeComponent();
            InitializePlaceholder();
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Gérer le clic du bouton
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // La case à cocher a été cochée, exécutez votre logique ici
        }

        internal static void Navigate(ExerciceWindow newPage)
        {
            throw new NotImplementedException();
        }

    }

}
