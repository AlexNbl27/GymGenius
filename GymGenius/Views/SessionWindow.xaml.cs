using GymGenius.Controllers;
using GymGenius.Models;
using GymGenius.ModelView;
using GymGenius.Utilities;
using System.Windows;

namespace GymGenius.Views
{
    public partial class SessionWindow : Window, ITimerHandler
    {

        private ASessionState currentState;
        private TimerController timer;
        private Session Session;
        private int currentExerciseIndex = 0;

        // ===== CONSTRUCT FUNCTIONS ===== //

        public SessionWindow(Session session)
        {
            InitializeComponent();
            this.Session = session;
            currentState = new ExerciseState(Session.exercises[currentExerciseIndex], currentExerciseIndex);
            currentState.CurrentExerciseIndexChanged += NextExerciseHandler;
            timer = new TimerController(this);
            InitializeFields();
        }

        public void InitializeFields()
        {
            ExerciseName.Text = Session.exercises[currentExerciseIndex].Name;
            ExerciseDesc.Text = Session.exercises[currentExerciseIndex].Description;
            Timer.Text = timer.currentTimeElapsed.TotalSeconds.ToString();
        }

        // ===== ACTION FUNCTIONS ===== //

        private void UpdateTextFields()
        {
            if (currentState is ExerciseState)
            {
                Timer.Text = "00:00";
                exerciseOverButtonText.Text = "Exercice terminé !";
                ExerciseName.Text = Session.exercises[currentExerciseIndex].Name;
                ExerciseDesc.Text = Session.exercises[currentExerciseIndex].Description;
            }
            else if (currentState is RestState)
            {
                List<double> secondsAndMinutes = Session.restTime.getDurationInMinutesAndSeconds();
                Timer.Text = secondsAndMinutes[1].ToString() + ":" + secondsAndMinutes[0].ToString();
                if (currentExerciseIndex < Session.exercises.Count)
                {
                    exerciseOverButtonText.Text = "Passer au prochain exercice";
                    ExerciseName.Text = "Repos";
                    ExerciseDesc.Text = "Prenez ce temps pour vous reposer !";
                }
                else
                {
                    exerciseOverButtonText.Text = "Terminer la séance";
                    ExerciseName.Text = "Repos";
                    ExerciseDesc.Text = "Dernier repos ! N'oubliez pas de vous ettirez après la séance !";
                }
            }
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            if (currentState is ExerciseState)
            {
                Timer.Text = timer.currentTimeElapsed.ToString(@"mm\:ss");
            }
            else if (currentState is RestState)
            {
                var restDuration = TimeSpan.FromSeconds(Session.restTime.getDurationInSecond());
                var remainingRestTime = restDuration - timer.currentTimeElapsed;
                Timer.Text = remainingRestTime.ToString(@"mm\:ss");
                if (timer.currentTimeElapsed >= restDuration)
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

        // ===== STATES HANDLER ===== //

        private void ChangeState(ASessionState newState)
        {
            timer.Reset();

            currentState?.OnExit();
            if (currentState != null)
            {
                currentState.CurrentExerciseIndexChanged -= NextExerciseHandler;
            }

            currentState = newState;
            currentState.CurrentExerciseIndexChanged += NextExerciseHandler;
            currentState?.OnEnter();

            UpdateTextFields();

            timer.Start();
        }

        private void NextExerciseHandler(int newIndex)
        {
            this.currentExerciseIndex = newIndex;
        }

        // ==== CLICK FUNCTIONS ===== //

        public void EndSession()
        {
            timer.Stop();
            MessagesBox.InfosBox("Séance terminée !");
            Close();
        }

        private void StopButton(object sender, RoutedEventArgs e)
        {
            EndSession();
        }

        private void NextButton(object sender, RoutedEventArgs e)
        {
            if (currentState is ExerciseState)
            {
                if (currentExerciseIndex < Session.exercises.Count)
                {
                    ChangeState(new RestState());
                }
                else
                {
                    EndSession();
                }
            }
            else if (currentState is RestState)
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
}
