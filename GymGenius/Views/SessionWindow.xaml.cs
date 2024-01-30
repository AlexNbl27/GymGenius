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

namespace GymGenius.Views
{
    /// <summary>
    /// Logique d'interaction pour SessionWindow.xaml
    /// </summary>
    public partial class SessionWindow : Window
    {

        private SessionState currentState;
        private DispatcherTimer timer;
        private Session Session;
        private int currentExerciseIndex;
        private TimeSpan currentExerciseElapsed;
        private TimeSpan currentRestElapsed;
        public event EventHandler<SessionState> StateChanged;

        public SessionWindow(Session session)
        {
            InitializeComponent();

            currentState = SessionState.EnCours;
            this.Session = session;
            currentExerciseIndex = 0;

            InitializeTimer();
            initializeFields();
        }

        public enum SessionState
        {
            EnCours,
            Repos
        }


        private void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        public void initializeFields()
        {
            // Mettez à jour les TextBlocks avec les valeurs de l'exercice actuel
            ExerciseName.Text = Session.exercises[currentExerciseIndex].Name;
            ExerciseDesc.Text = Session.exercises[currentExerciseIndex].Description;
            Timer.Text = timer.ToString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Mettez à jour le temps écoulé de l'exercice actuel
            currentExerciseElapsed += TimeSpan.FromSeconds(1);

            // Vérifiez si le temps de l'exercice actuel est écoulé
            if (currentExerciseElapsed.TotalSeconds >= Session.exercises[currentExerciseIndex].Duration.getDurationInSecond())
            {
                // Si le temps est écoulé, passez à l'état Repos
                ChangeState(SessionState.Repos);

                // Réinitialisez le temps écoulé pour l'exercice actuel
                currentExerciseElapsed = TimeSpan.Zero;

                // Passez à l'exercice suivant
                currentExerciseIndex++;

                // Vérifiez s'il reste des exercices à effectuer
                if (currentExerciseIndex < Session.exercises.Count)
                {
                    currentRestElapsed += TimeSpan.FromSeconds(1);

                    // Vérifiez si le temps de repos est écoulé
                    if (currentRestElapsed.TotalSeconds >= Session.restTime.getDurationInSecond())
                    {
                        // Si le temps est écoulé, passez à l'état EnCours
                        ChangeState(SessionState.EnCours);

                        // Réinitialisez le temps écoulé pour le repos
                        currentRestElapsed = TimeSpan.Zero;
                    }
                }
                else
                {
                    // Si tous les exercices sont terminés, arrêtez le timer
                    EndSession();
                }
            }
        }

        public void EndSession()
        {
            timer.Stop();
            Close();
        }

        private void StopButton(object sender, RoutedEventArgs e)
        {
            EndSession();
        }

        private void ChangeState(SessionState newState)
        {
            currentState = newState;
            StateChanged?.Invoke(this, currentState);
        }
    }
}
