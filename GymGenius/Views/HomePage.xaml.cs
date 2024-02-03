using GymGenius.Controllers;
using GymGenius.Models;
using GymGenius.Utilities;
using GymGenius.Views;
using System.Windows;
using System.Windows.Controls;

namespace GymGenius
{
    public partial class HomePage : Page
    {
        private readonly MainWindow mainWindow;

        public HomePage(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            InitializeComponent();
        }

        // ===== CLICK FUNCTIONS ===== /

        private void ExerciseButtonClick(object sender, RoutedEventArgs e)
        {
            if (VerifyRestTime())
            {
                GetSessionDate();
                GetSessionReccurence();
                mainWindow.NavigateToPage(new ExercisesPage(mainWindow));
            }
        }

        private void ImportButtonClick(object sender, RoutedEventArgs e)
        {
            if (VerifyRestTime())
            {
                bool importSuccess = false;
                do
                {
                    ICSUtils ics = new();
                    this.mainWindow.session = ics.ImportICS();

                    if (this.mainWindow.session != null)
                    {
                        importSuccess = true;
                    }
                    else
                    {
                        MessagesBox.InfosBox("Echec de l'import");
                    }
                } while (!importSuccess);

                mainWindow.NavigateToPage(new RecapSessionPage(mainWindow));
            }
        }

        // ===== HANDLE FUNCTIONS ===== /

        private bool VerifyRestTime()
        {
            bool restTimeAcquired = false;
            do
            {
                restTimeAcquired = GetRestTime();
                if (restTimeAcquired || !MessagesBox.WarnUser("Vous devez entrez une valeur valide dans le champs de la durée de repos entre les exercices !"))
                {
                    break;
                }
            } while (true);

            return restTimeAcquired;
        }

        private bool GetRestTime()
        {
            int timeBetweenExercises = 0;

            if (int.TryParse(timexo.Text, out timeBetweenExercises))
            {
                this.mainWindow.session.restTime = new TimeController(0, 0, timeBetweenExercises);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GetSessionDate()
        {
            DatePicker datePickerExercise = FindName("DatePickerExercise") as DatePicker;

            if (datePickerExercise != null)
            {
                this.mainWindow.session.date = datePickerExercise.SelectedDate;
            }
        }

        private void GetSessionReccurence()
        {
            List<int> checkedTags = new List<int>();

            foreach (var child in recurrence.Children)
            {
                if (child is CheckBox checkBox && checkBox.IsChecked == true)
                {
                    checkedTags.Add(int.Parse(checkBox.Tag.ToString()));
                }
            }

            if (checkedTags.Count > 0)
            {
                this.mainWindow.session.recurrenceId = checkedTags[0];
            }
        }

        // ===== WINDOW FUNCTIONS =====/

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;

            foreach (var child in recurrence.Children)
            {
                if (child is CheckBox otherCheckBox && otherCheckBox != checkBox)
                {
                    otherCheckBox.IsChecked = false;
                }
            }
        }
    }
}