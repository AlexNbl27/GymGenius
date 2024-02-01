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
using GymGenius.Controllers;

namespace GymGenius
{
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
            int timeBetweenExercises = 0;

            if (int.TryParse(timexo.Text, out timeBetweenExercises))
            {
                // Creating a session with the specified time intervals
                Session session = new Session(new TimeController(0, 0, timeBetweenExercises));

                // Showing the Exercise window
                Show();
                ExerciceWindow exerciceWindow = new ExerciceWindow(session);
                exerciceWindow.Show();
            }
            else
            {
                MessageBox.Show("Entrée invalide pour le repos entre les exercices !");
            }
        }

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            int timeBetweenExercises = 0;
            if (int.TryParse(timexo.Text, out timeBetweenExercises))
            {
                Show();
                ICSUtils ics = new();
                Session session = ics.ImportICS();
                session.restTime.setTime(0, 0, timeBetweenExercises);
                var date = GetDatePicker();
                if(date != null)
                {
                    session.date = (DateTime)date;
                }
                if (session != null)
                {
                    Seance seance = new(session);
                    seance.Show();
                }
            }
            else
            {
                MessageBox.Show("Entrée invalide pour le repos entre les exercices !");
            } 
        }

        private DateTime? GetDatePicker()
        {
            DatePicker datePickerExercise = FindName("DatePickerExercise") as DatePicker;

            if (datePickerExercise != null)
            {
                return datePickerExercise.SelectedDate = DateTime.Today;
            }
            return null;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // La case à cocher a été cochée, exécutez votre logique ici
        }
    }
}