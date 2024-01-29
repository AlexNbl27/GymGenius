using GymGenius.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GymGenius.Models;
using GymGenius.Utilities;

namespace GymGenius
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
   
        public MainWindow()
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
        }

        private void ShowPlaceholder()
        {
        }

        private void HidePlaceholder()
        {
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Show();
            ExerciceWindow exerciceWindow = new();
            exerciceWindow.Show();
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            Show();
            ICSUtils ics = new();
            Session session = ics.ImportICS();
            if (session != null)
            {
                Seance seance = new(session);
                seance.Show();
            }   
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // La case à cocher a été cochée, exécutez votre logique ici
        }
    }
}