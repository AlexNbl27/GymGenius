using GymGenius.Controllers;
using GymGenius.Models;
using GymGenius.Utilities;
using GymGenius.Views;
using System.Windows;
using System.Windows.Controls;

namespace GymGenius
{
    public partial class HomeWindow : Window
    {
        Session session = new Session();

        public HomeWindow()
        {
            InitializeComponent();
        }

        // ===== CLICK FUNCTIONS ===== /

        private void ExerciseButtonClick(object sender, RoutedEventArgs e)
        {
            if (VerifyRestTime())
            {
                GetSessionDate();
                GetSessionReccurence();
                ExerciceWindow exerciceWindow = new ExerciceWindow(session);
                exerciceWindow.Show();
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
                    this.session = ics.ImportICS();

                    if (session != null)
                    {
                        importSuccess = true;
                    }
                    else
                    {
                        MessagesBox.InfosBox("Echec de l'import");
                    }
                } while (!importSuccess);

                RecapSessionWindow seance = new(this.session);
                seance.Show();
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
                this.session.restTime = new TimeController(0, 0, timeBetweenExercises);
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
                session.date = datePickerExercise.SelectedDate;
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
                session.recurrenceId = checkedTags[0];
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