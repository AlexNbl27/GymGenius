using GymGenius.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GymGenius.Views
{
    public partial class ExerciceWindow : Window
    {
        // Property to store the list of exercises
        public List<AExercise> Exercises { get; set; }
        public List<AExercise> selectedExercises { get; set; } = new List<AExercise>();
        public Session Session { get; set; }

        public ExerciceWindow(Session session)
        {
            InitializeComponent();

            Exercises = new List<AExercise>
            {
                new PushUps(),
                new PullUps(),
                new Dips(),
                new BenchPress(),
                new InclinedBenchPress(),
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
                new LegsExtensions(),
                new LegsExtensions(),
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

        public ExerciceWindow(Session session, List<AExercise> filteredExercises)
        {
            InitializeComponent();
            Exercises = filteredExercises;
            this.Session = session;

            // Set the DataContext to this window so that bindings work
            DataContext = this;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
            this.Exercises = new List<AExercise>();

            if (jambe.IsChecked.GetValueOrDefault())
            {
                this.Exercises.Add(new Squat());
                this.Exercises.Add(new LegPress());
                this.Exercises.Add(new Slots());
                this.Exercises.Add(new LegsExtensions());
                this.Exercises.Add(new LegsExtensions());
                this.Exercises.Add(new CalfPress());
            }
            if (dos.IsChecked.GetValueOrDefault())
            {
                this.Exercises.Add(new PullUps());
                this.Exercises.Add(new HorizontalDraft());
                this.Exercises.Add(new Deadlift());
                this.Exercises.Add(new FacePull());
                this.Exercises.Add(new InvertedPecDeck());
            }
            if (epaule.IsChecked.GetValueOrDefault())
            {
                this.Exercises.Add(new MilitaryPress());
                this.Exercises.Add(new SideElevation());
                this.Exercises.Add(new FrontalElevation());
                this.Exercises.Add(new BirdElevation());
            }
            if (pec.IsChecked.GetValueOrDefault())
            {
                this.Exercises.Add(new BenchPress());
                this.Exercises.Add(new InclinedBenchPress());
                this.Exercises.Add(new ForeheadBar());
                this.Exercises.Add(new PulleyTricepsExtensions());
                this.Exercises.Add(new CableMiddleFly());
            }
            if (bras.IsChecked.GetValueOrDefault())
            {
                this.Exercises.Add(new BicepsCurl());
                this.Exercises.Add(new CurlRotation());
                this.Exercises.Add(new PulleyCurl());
            }
            if (tronc.IsChecked.GetValueOrDefault())
            {
                this.Exercises.Add(new Crunch());
            }
            if (this.Exercises.Count == 0)
            {
                this.Exercises = new List<AExercise>
                {
                    new PushUps(),
                    new PullUps(),
                    new Dips(),
                    new BenchPress(),
                    new InclinedBenchPress(),
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
                    new LegsExtensions(),
                    new LegsExtensions(),
                    new CalfPress(),
                    new Treadmill(),
                    new Rowing(),
                    new Stairs(),
                    new Elliptical()
                };
            }
            if (numericTextBox.Text != "")
            {
                List<AExercise> tmp = new List<AExercise>();
                int difficulty = int.Parse(numericTextBox.Text);
                foreach (var item in this.Exercises)
                {
                    if (item.Level <= difficulty)
                    {
                        tmp.Add(item);
                    }
                }
                this.Exercises = tmp;
            }
            if (cardio.IsChecked.GetValueOrDefault())
            {
                List<AExercise> tmp = new List<AExercise>();
                foreach (var item in this.Exercises)
                {
                    if (item.Type is Cardio)
                    {
                        tmp.Add(item);
                    }
                }
                this.Exercises = tmp;
            }
            if (musculaire.IsChecked.GetValueOrDefault())
            {
                List<AExercise> tmp = new List<AExercise>();
                foreach (var item in this.Exercises)
                {
                    if (item.Type is Muscular)
                    {
                        tmp.Add(item);
                    }
                }
                this.Exercises = tmp;
            }

            Close();
            ExerciceWindow exerciceWindow = new(this.Session, this.Exercises);
            exerciceWindow.Show();

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
