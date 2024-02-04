using GymGenius.Controllers;
using GymGenius.Models;
using GymGenius.Utilities;
using GymGenius.Views;
using System.Windows;
using System.Windows.Controls;

namespace GymGenius.ViewModels
{
    public class HomePageViewModel
    {
        private readonly MainWindow mainWindow;

        public HomePageViewModel(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
        }

        public void OnExerciseButtonClick(string timeBetweenExercises, DatePicker datePickerExercise, Panel recurrence, MainWindow mainWindow)
        {
            if (VerifyRestTime(timeBetweenExercises))
            {
                GetSessionDate(datePickerExercise);
                GetSessionReccurence(recurrence);
                mainWindow.NavigateToPage(new ExercisesPage(mainWindow));
            }
            else
            {
                MessagesBox.InfosBox("Veuillez entrer un temps de repos valide");
            }
        }

        public void OnImportButtonClick(string timeBetweenExercises, MainWindow mainWindow)
        {
            if (VerifyRestTime(timeBetweenExercises))
            {
                ICSUtils ics = new();
                Session _session = ics.ImportICS();
                if (_session != null)
                {
                    mainWindow.session = _session;
                    mainWindow.NavigateToPage(new RecapSessionPage(mainWindow));
                }
                else
                {
                    MessageBox.Show("Echec de l'import");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un temps de repos valide");
            }
        }

        public bool VerifyRestTime(string timeBetweenExercises)
        {
            if (int.TryParse(timeBetweenExercises, out int time))
            {
                if (time > 0)
                {
                    mainWindow.session.restTime = new TimeController(time);
                    return true;
                }
            }
            return false;
        }

        public void GetSessionDate(DatePicker datePickerExercise)
        {
            if (datePickerExercise != null)
            {
                mainWindow.session.date = datePickerExercise.SelectedDate;
            }
        }

        public void GetSessionReccurence(Panel recurrence)
        {
            List<int> checkedTags = [];

            foreach (object? child in recurrence.Children)
            {
                if (child is CheckBox checkBox && checkBox.IsChecked == true)
                {
                    checkedTags.Add(int.Parse(checkBox.Tag.ToString()));
                }
            }

            if (checkedTags.Count > 0)
            {
                mainWindow.session.recurrenceId = checkedTags[0];
            }
        }

        public void OnCheckBoxChecked(object sender, UIElementCollection children)
        {
            CheckBox? checkBox = sender as CheckBox;

            foreach (object? child in children)
            {
                if (child is CheckBox otherCheckBox && otherCheckBox != checkBox)
                {
                    otherCheckBox.IsChecked = false;
                }
            }
        }
    }
}