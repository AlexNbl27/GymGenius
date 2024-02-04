using GymGenius.Models;
using GymGenius.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GymGenius.Views
{
    public partial class ExercisesPage : Page
    {
        private readonly ExercisesPageViewModel viewModel;

        public ExercisesPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            viewModel = new ExercisesPageViewModel(_mainWindow);
            DataContext = viewModel;
        }

        public ExercisesPage(MainWindow _mainWindow, List<AExercise> filteredExercises)
        {
            InitializeComponent();
            viewModel = new ExercisesPageViewModel(_mainWindow);
            DataContext = viewModel;
            viewModel.Exercises = filteredExercises;
        }

        // ===== INPUT FUNCTIONS ===== //
        // These functions are used to handle the input of the user on this page

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

        // ===== MOUSE FUNCTIONS ===== //
        // These functions are used to handle the mouse events on this page, their only purpose is to decorate

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
                    viewModel.AddExercise(clickedExercise);
                }
            }
        }
    }
}
