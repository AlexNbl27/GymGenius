using GymGenius.Controllers;
using GymGenius.Models;
using GymGenius.ModelView;
using GymGenius.Utilities;
using System.Windows;
using System.Windows.Controls;

namespace GymGenius.Views
{
    public partial class SessionPage : Page, ITimerHandler
    {
        private readonly MainWindow mainWindow;

        private ASessionState currentState;
        private TimerController timer;
        private int currentExerciseIndex = 0;

        // ===== CONSTRUCT FUNCTIONS ===== //

        public SessionPage(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            InitializeComponent();
            currentState = new ExerciseState(this.mainWindow.session.exercises[currentExerciseIndex], currentExerciseIndex);
            currentState.CurrentExerciseIndexChanged += NextExerciseHandler;
            timer = new TimerController(this);
            InitializeFields();
        }

        public void InitializeFields()
        {
            ExerciseName.Text = this.mainWindow.session.exercises[currentExerciseIndex].Name;
            ExerciseDesc.Text = this.mainWindow.session.exercises[currentExerciseIndex].Description;
            Timer.Text = "00:00";
        }

        // ===== ACTION FUNCTIONS ===== //

        private void UpdateTextFields()
        {
            if (currentState is ExerciseState)
            {
                Timer.Text = "00:00";
                exerciseOverButtonText.Text = "Exercice terminé !";
                ExerciseName.Text = this.mainWindow.session.exercises[currentExerciseIndex].Name;
                ExerciseDesc.Text = this.mainWindow.session.exercises[currentExerciseIndex].Description;
            }
            else if (currentState is RestState)
            {
                List<double> secondsAndMinutes = this.mainWindow.session.restTime.getDurationInMinutesAndSeconds();
                string seconds = $"{(secondsAndMinutes[0] < 10 ? "0" : "")}{secondsAndMinutes[0]}";
                string minutes = $"{(secondsAndMinutes[1] < 10 ? "0" : "")}{secondsAndMinutes[1]}";
                Timer.Text = minutes + ":" + seconds;
                if (currentExerciseIndex < this.mainWindow.session.exercises.Count)
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
                var restDuration = TimeSpan.FromSeconds(this.mainWindow.session.restTime.getDurationInSecond());
                var remainingRestTime = restDuration - timer.currentTimeElapsed;
                Timer.Text = remainingRestTime.ToString(@"mm\:ss");
                if (timer.currentTimeElapsed >= restDuration)
                {
                    if (currentExerciseIndex < this.mainWindow.session.exercises.Count)
                    {
                        ChangeState(new ExerciseState(this.mainWindow.session.exercises[currentExerciseIndex], currentExerciseIndex));
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
            this.mainWindow.Close();
        }

        private void StopButton(object sender, RoutedEventArgs e)
        {
            EndSession();
        }

        private void NextButton(object sender, RoutedEventArgs e)
        {
            if (currentState is ExerciseState)
            {
                if (currentExerciseIndex < this.mainWindow.session.exercises.Count)
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
                if (currentExerciseIndex < this.mainWindow.session.exercises.Count)
                {
                    ChangeState(new ExerciseState(this.mainWindow.session.exercises[currentExerciseIndex], currentExerciseIndex));
                }
                else
                {
                    EndSession();
                }
            }
        }
    }
}
