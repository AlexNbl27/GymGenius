using GymGenius.Models;
using GymGenius.ModelView;
using GymGenius.Utilities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GymGenius.Views
{
    public partial class ExercisesPage : Page
    {
        private readonly MainWindow mainWindow;

        public List<AExercise> Exercises { get; set; }

        // ===== CONSTRUCT FUNCTIONS ===== //

        public ExercisesPage(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            InitializeComponent();
            ExercisesLogic exercisesLogic = new();
            Exercises = exercisesLogic.GetAllExercises();

            // Set the DataContext to this window so that bindings work
            DataContext = this;
        }

        public ExercisesPage(MainWindow _mainWindow, List<AExercise> filteredExercises)
        {
            mainWindow = _mainWindow;
            InitializeComponent();
            Exercises = filteredExercises;

            // Set the DataContext to this window so that bindings work
            DataContext = this;
        }


        // ===== CLICK FUNCTIONS ===== //

        private void CreateSessionButton(object sender, RoutedEventArgs e)
        {
            if (mainWindow.session.exercises.Count != 0)
            {
                mainWindow.NavigateToPage(new RecapSessionPage(mainWindow));
            }
            else
            {
                MessagesBox.InfosBox("Veuillez sélectionner au moins un exercice");
            }
        }

        private void OnSearchClick(object sender, RoutedEventArgs e)
        {
            Exercises.Clear();
            List<AExercise> tmp = [];
            ExercisesLogic exercisesLogic = new();

            tmp = dos.IsChecked.GetValueOrDefault() || jambe.IsChecked.GetValueOrDefault() || bras.IsChecked.GetValueOrDefault() || epaule.IsChecked.GetValueOrDefault() || tronc.IsChecked.GetValueOrDefault() || numericTextBox.Text != "" || cardio.IsChecked.GetValueOrDefault() || musculaire.IsChecked.GetValueOrDefault()
                ? numericTextBox.Text != ""
                    ? exercisesLogic.GetFilteredExercises(jambe.IsChecked.GetValueOrDefault(), bras.IsChecked.GetValueOrDefault(), dos.IsChecked.GetValueOrDefault(), epaule.IsChecked.GetValueOrDefault(), tronc.IsChecked.GetValueOrDefault(), cardio.IsChecked.GetValueOrDefault(), musculaire.IsChecked.GetValueOrDefault(), int.Parse(numericTextBox.Text))
                    : exercisesLogic.GetFilteredExercises(jambe.IsChecked.GetValueOrDefault(), bras.IsChecked.GetValueOrDefault(), dos.IsChecked.GetValueOrDefault(), epaule.IsChecked.GetValueOrDefault(), tronc.IsChecked.GetValueOrDefault(), cardio.IsChecked.GetValueOrDefault(), musculaire.IsChecked.GetValueOrDefault())
                : exercisesLogic.GetAllExercises();

            mainWindow.NavigateToPage(new ExercisesPage(mainWindow, tmp));
        }

        // ===== INPUT FUNCTIONS ===== //

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }

            if (int.TryParse(numericTextBox.Text + e.Text, out int result) && result > 5)
            {
                e.Handled = true;
            }
        }

        private void numericTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox clickedCheckBox = sender as CheckBox;

            if (clickedCheckBox == cardio && cardio.IsChecked == true)
            {
                musculaire.IsChecked = false;
            }
            else if (clickedCheckBox == musculaire && musculaire.IsChecked == true)
            {
                cardio.IsChecked = false;
            }
        }

        // ===== MOUSE FUNCTIONS ===== //

        private void ExerciseComponent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Components.ExerciseComponent exerciseComponent)
            {
                exerciseComponent.Border.BorderBrush = System.Windows.Media.Brushes.Blue;
            }
        }

        private void ExerciseComponent_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Components.ExerciseComponent exerciseComponent)
            {
                exerciseComponent.Border.BorderBrush = System.Windows.Media.Brushes.Black;

                if (exerciseComponent.DataContext is AExercise clickedExercise)
                {
                    mainWindow.session.exercises.Add(clickedExercise);
                }
            }
        }
    }
}
