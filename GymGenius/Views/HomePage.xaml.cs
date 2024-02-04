using GymGenius.Controllers;
using GymGenius.Models;
using GymGenius.Utilities;
using GymGenius.ViewModels;
using GymGenius.Views;
using System.Windows;
using System.Windows.Controls;

namespace GymGenius
{
    public partial class HomePage : Page
    {
        // ===== PROPERTIES ===== /

        private readonly MainWindow mainWindow;
        private readonly HomePageViewModel viewModel;

        // ===== CONSTRUCTOR ===== /

        public HomePage(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            InitializeComponent();
            viewModel = new HomePageViewModel(_mainWindow);
        }

        // ===== CLICK FUNCTIONS ===== //
        // These functions calls are triggered when the user clicks on a button and call the global navigation function to change the page

        private void ExerciseButtonClick(object sender, RoutedEventArgs e)
        {
            if (viewModel.VerifyRestTime(timexo.Text))
            {
                viewModel.GetSessionDate(DatePickerExercise);
                viewModel.GetSessionReccurence(recurrence);
                mainWindow.NavigateToPage(new ExercisesPage(mainWindow));
            }
            else
            {
                MessagesBox.InfosBox("Veuillez entrer un temps de repos valide");
            }
        }

        private void ImportButtonClick(object sender, RoutedEventArgs e)
        {
            if (viewModel.VerifyRestTime(timexo.Text))
            {
                ICSUtils ics = new();
                Session _session = ics.ImportICS();
                if (_session != null)
                {
                    mainWindow.session = _session;
                    mainWindow.session.restTime = new TimeController(int.Parse(timexo.Text));
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

        // ===== INPUT FUNCTIONS ===== //
        // These functions are only used in this file to handle the user inputs

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox? checkBox = sender as CheckBox;

            foreach (object? child in recurrence.Children)
            {
                if (child is CheckBox otherCheckBox && otherCheckBox != checkBox)
                {
                    otherCheckBox.IsChecked = false;
                }
            }
        }
    }
}