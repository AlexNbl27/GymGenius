using GymGenius.Controllers;
using GymGenius.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GymGenius.Views
{
    public partial class ExerciceWindow : Window
    {
        // Property to store the list of exercises
        public List<AExercise> Exercises { get; set; }
        public List<AExercise> selectedExercises { get; set; }
        public Session Session { get; set; }

        public ExerciceWindow(Session session)
        {
            InitializeComponent();
            InitializePlaceholder();
            this.selectedExercises = new List<AExercise>();

            // Initialize the list of exercises
            Exercises = new List<AExercise>
            {
                new PushUps(),
                new PullUps(),
                new Dips(),
                new BenchPress(),
                new InclineBenchPress(),
                new ForeheadBar(),
                new PulleyTricepsExtensions(),
                new CableMiddleFly(),
                new Crunch(),
                new SideElevation(),
                new FrontalElevation(),
                new BirdElevation(),
                new MilitaryPress(),
                new InvertedPecDeck(),
                new FacePull(),
                new HorizontalDraft(),
                new Deadlift(),
                new BicepsCurl(),
                new CurlRotation(),
                new PulleyCurl(),
                new Squat(),
                new LegPress(),
                new Slots(),
                new LegExtension(),
                new LegFlexion(),
                new CalfPress(),
                new Treadmill(),
                new Rowing(),
                new Stairs(),
                new Elliptical()
            };

            this.Session = session;

            // Set the DataContext to this window so that bindings work
            DataContext = this;
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
            searchbar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6D887B"));
        }

        private void HidePlaceholder()
        {
            if (searchbar.Text == "Rechercher un exercice en particulier")
            {
                searchbar.Text = string.Empty;
                searchbar.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#25322C"));
                searchbar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6D887B"));
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Handle checkbox checked event
            // La case à cocher a été cochée, exécutez votre logique ici
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Session.exercises = this.selectedExercises;
            Seance seance = new(this.Session);
            seance.Show();
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Valider que la saisie est un chiffre
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }

            // Limiter la valeur maximale à 5
            if (int.TryParse(numericTextBox.Text + e.Text, out int result) && result > 5)
            {
                e.Handled = true;
            }
        }

        private void numericTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void OnSearch_click(object sender, RoutedEventArgs e)
        {
            // Handle search button click event
        }

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
