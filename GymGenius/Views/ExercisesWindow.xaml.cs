using GymGenius.Models;
using GymGenius.ModelView;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GymGenius.Views
{
    public partial class ExercisesWindow : Window
    {
        // Property to store the list of exercises
        public List<AExercise> Exercises { get; set; }
        public List<AExercise> selectedExercises { get; set; } = new List<AExercise>();
        public Session Session { get; set; }

        // ===== CONSTRUCT FUNCTIONS ===== //

        public ExercisesWindow(Session session)
        {
            InitializeComponent();
            ExercisesLogic exercisesLogic = new();
            Exercises = exercisesLogic.GetAllExercises();
            this.Session = session;

            // Set the DataContext to this window so that bindings work
            DataContext = this;
        }

        public ExercisesWindow(Session session, List<AExercise> filteredExercises)
        {
            InitializeComponent();
            Exercises = filteredExercises;
            this.Session = session;

            // Set the DataContext to this window so that bindings work
            DataContext = this;
        }


        // ===== CLICK FUNCTIONS ===== //

        private void CreateSessionButton(object sender, RoutedEventArgs e)
        {
            if (this.selectedExercises.Count != 0)
            {
                this.Session.exercises = this.selectedExercises;
                RecapSessionWindow seance = new(this.Session);
                seance.Show();
            }
            else
            {
                MessageBox.Show("Sélectionnez au moins un exercice !");
            }
        }

        private void OnSearch_click(object sender, RoutedEventArgs e)
        {
            this.Exercises.Clear();
            List<AExercise> tmp = new List<AExercise>();
            ExercisesLogic exercisesLogic = new();

            if (dos.IsChecked.GetValueOrDefault() || jambe.IsChecked.GetValueOrDefault() || bras.IsChecked.GetValueOrDefault() || epaule.IsChecked.GetValueOrDefault() || tronc.IsChecked.GetValueOrDefault() || numericTextBox.Text != "" || cardio.IsChecked.GetValueOrDefault() || musculaire.IsChecked.GetValueOrDefault())
            {
                if (numericTextBox.Text != "")
                {
                    tmp = exercisesLogic.GetFilteredExercises(jambe.IsChecked.GetValueOrDefault(), bras.IsChecked.GetValueOrDefault(), dos.IsChecked.GetValueOrDefault(), epaule.IsChecked.GetValueOrDefault(), tronc.IsChecked.GetValueOrDefault(), cardio.IsChecked.GetValueOrDefault(), musculaire.IsChecked.GetValueOrDefault(), int.Parse(numericTextBox.Text));
                }
                else
                {
                    tmp = exercisesLogic.GetFilteredExercises(jambe.IsChecked.GetValueOrDefault(), bras.IsChecked.GetValueOrDefault(), dos.IsChecked.GetValueOrDefault(), epaule.IsChecked.GetValueOrDefault(), tronc.IsChecked.GetValueOrDefault(), cardio.IsChecked.GetValueOrDefault(), musculaire.IsChecked.GetValueOrDefault());
                }
            }
            else
            {
                tmp = exercisesLogic.GetAllExercises();
            }

            Close();
            ExercisesWindow exerciceWindow = new(this.Session, tmp);
            exerciceWindow.Show();
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

            // If the first checkbox is checked, uncheck the second checkbox
            if (clickedCheckBox == cardio && cardio.IsChecked == true)
            {
                musculaire.IsChecked = false;
            }
            // If the second checkbox is checked, uncheck the first checkbox
            else if (clickedCheckBox == musculaire && musculaire.IsChecked == true)
            {
                cardio.IsChecked = false;
            }
        }

        // ===== ACTIONS FUNCTIONS ===== //

        public event EventHandler<AExercise> ExerciseClicked;

        private void ExerciseComponent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Components.ExerciseComponent exerciseComponent)
            {
                // Change border color to blue when mouse button is pressed
                if (exerciseComponent.FindName("ExerciseBorder") is Border border)
                {
                    exerciseComponent.BorderBrush = System.Windows.Media.Brushes.Blue;
                }
            }
        }

        private void ExerciseComponent_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Components.ExerciseComponent exerciseComponent)
            {
                // Change border color back to black when mouse button is released
                if (exerciseComponent.FindName("ExerciseBorder") is Border border)
                {
                    exerciseComponent.BorderBrush = System.Windows.Media.Brushes.Black;
                }

                if (exerciseComponent.DataContext is AExercise clickedExercise)
                {
                    // Add the clicked exercise to selectedExercises
                    selectedExercises.Add(clickedExercise);
                }
            }
        }

    }
}
