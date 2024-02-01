using GymGenius.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using static GymGenius.Views.SessionWindow;

namespace GymGenius.Views
{
    public partial class SessionWindow : Window
    {

        private AState currentState;
        private DispatcherTimer timer;
        private Session Session;
        private int currentExerciseIndex;
        private TimeSpan currentExerciseElapsed;
        private TimeSpan currentRestElapsed;

        public SessionWindow(Session session)
        {
            InitializeComponent();

            this.Session = session;
            currentExerciseIndex = 0;

            initializeFields();
            InitializeTimer();
            currentState = new ExerciseState(Session.exercises[currentExerciseIndex], currentExerciseIndex);

            currentState.ExerciseNameChanged += ExerciseNameChangedHandler;
            currentState.ExerciseDescriptionChanged += ExerciseDescriptionChangedHandler;
            currentState.CurrentExerciseIndexChanged += NextExerciseHandler;
        }

        private void ExerciseNameChangedHandler(string newName)
        {
            ExerciseName.Text = newName;
        }

        // Gestionnaire d'événements pour le changement de description de l'exercice
        private void ExerciseDescriptionChangedHandler(string newDescription)
        {
            ExerciseDesc.Text = newDescription;
        }

        private void NextExerciseHandler(int newIndex)
        {
            this.currentExerciseIndex = newIndex;
        }

        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        public void initializeFields()
        {
            // Mettez à jour les TextBlocks avec les valeurs de l'exercice actuel
            ExerciseName.Text = Session.exercises[currentExerciseIndex].Name;
            ExerciseDesc.Text = Session.exercises[currentExerciseIndex].Description;
            Timer.Text = currentExerciseElapsed.TotalSeconds.ToString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentState is ExerciseState)
            {
                exerciseOverButtonText.Text = "Exercice terminé !";
                currentExerciseElapsed = currentExerciseElapsed.Add(TimeSpan.FromSeconds(1));
                Timer.Text = currentExerciseElapsed.ToString(@"mm\:ss");
            }
            else if (currentState is RestState)
            {
                if(currentExerciseIndex < Session.exercises.Count)
                {
                    exerciseOverButtonText.Text = "Passer au prochain exercice";
                } else
                {
                    exerciseOverButtonText.Text = "Terminer la séance";
                }
                currentRestElapsed = currentRestElapsed.Add(TimeSpan.FromSeconds(1));
                //var restDuration = TimeSpan.FromSeconds(30);
                var restDuration = TimeSpan.FromSeconds(Session.restTime.getDurationInSecond());
                var remainingRestTime = restDuration - currentRestElapsed;
                Timer.Text = remainingRestTime.ToString(@"mm\:ss");
                if (currentRestElapsed >= restDuration)
                {
                    if (currentExerciseIndex < Session.exercises.Count)
                    {
                        ChangeState(new ExerciseState(Session.exercises[currentExerciseIndex], currentExerciseIndex));
                    }
                    else
                    {
                        EndSession();
                    }
                }
            }
        }

        public void EndSession()
        {
            timer.Stop();
            MessageBox.Show("Séance terminée !");
            Close();
        }

        private void StopButton(object sender, RoutedEventArgs e)
        {
            EndSession();
        }

        private void NextButton(object sender, RoutedEventArgs e)
        {
            if(currentState is ExerciseState)
            {
                if (currentExerciseIndex < Session.exercises.Count)
                {
                    ChangeState(new RestState());
                }
                else
                {
                    EndSession();
                }
            } else if (currentState is RestState)
            {
                if (currentExerciseIndex < Session.exercises.Count)
                {
                    ChangeState(new ExerciseState(Session.exercises[currentExerciseIndex], currentExerciseIndex));
                }
                else
                {
                    EndSession();
                }
            }
        }

        private void ChangeState(AState newState)
        {
            // Stop the current timer
            timer.Stop();
            currentExerciseElapsed = TimeSpan.Zero;
            currentRestElapsed = TimeSpan.Zero;

            // Call the OnExit method of the current state
            currentState?.OnExit();

            // Unsubscribe from the events of the current state
            if (currentState != null)
            {
                currentState.ExerciseNameChanged -= ExerciseNameChangedHandler;
                currentState.ExerciseDescriptionChanged -= ExerciseDescriptionChangedHandler;
                currentState.CurrentExerciseIndexChanged -= NextExerciseHandler;
            }

            // Assign the new state
            currentState = newState;

            // Subscribe to the events of the new state
            currentState.ExerciseNameChanged += ExerciseNameChangedHandler;
            currentState.ExerciseDescriptionChanged += ExerciseDescriptionChangedHandler;
            currentState.CurrentExerciseIndexChanged += NextExerciseHandler;

            // Call the OnEnter method of the new state
            currentState?.OnEnter();

            // Reset and start the timer
            timer.Start();
        }


        public abstract class AState
        {
            public event Action<string> ExerciseNameChanged;
            public event Action<string> ExerciseDescriptionChanged;
            public event Action<int> CurrentExerciseIndexChanged;

            // Define methods to raise the events
            protected void RaiseExerciseNameChanged(string newName)
            {
                ExerciseNameChanged?.Invoke(newName);
            }

            protected void RaiseExerciseDescriptionChanged(string newDescription)
            {
                ExerciseDescriptionChanged?.Invoke(newDescription);
            }

            protected void RaiseCurrentExerciseIndexChanged(int newIndex)
            {
                CurrentExerciseIndexChanged?.Invoke(newIndex);
            }

            public abstract void OnEnter();
            public abstract void OnExit();
        }


        public class ExerciseState : AState
        {
            AExercise currentExercise;
            int currentExerciseIndex;

            public ExerciseState(AExercise _currentExercise, int _currentExerciseIndex) { 
                this.currentExercise = _currentExercise;
                this.currentExerciseIndex = _currentExerciseIndex;
            }

            public override void OnEnter()
            {
                RaiseExerciseNameChanged(this.currentExercise.Name);
                RaiseExerciseDescriptionChanged(this.currentExercise.Description);
            }

            public override void OnExit()
            {
                RaiseCurrentExerciseIndexChanged(this.currentExerciseIndex + 1);
            }

        }

        class RestState : AState
        {

            public override void OnEnter()
            {
                RaiseExerciseNameChanged("Repos");
                RaiseExerciseDescriptionChanged("Prenez ce temps pour vous reposer");
            }

            public override void OnExit()
            {
            }
        }
    }
}
