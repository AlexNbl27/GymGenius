using GymGenius.Controllers;
using GymGenius.Models;
using GymGenius.Utilities;
using GymGenius.Views;

public class SessionPageViewModel : ViewModelBase, ITimerHandler
{
    private readonly MainWindow mainWindow;
    private ASessionState currentState;
    private readonly TimerController timer;
    private int currentExerciseIndex = 0;

    private string _exerciseName;
    public string ExerciseName
    {
        get { return _exerciseName; }
        set
        {
            _exerciseName = value;
            OnPropertyChanged("ExerciseName");
        }
    }

    private string _exerciseDesc;
    public string ExerciseDesc
    {
        get { return _exerciseDesc; }
        set
        {
            _exerciseDesc = value;
            OnPropertyChanged("ExerciseDesc");
        }
    }

    private string _timer;
    public string Timer
    {
        get { return _timer; }
        set
        {
            _timer = value;
            OnPropertyChanged("Timer");
        }
    }

    private string _exerciseOverButtonText;
    public string exerciseOverButtonText
    {
        get { return _exerciseOverButtonText; }
        set
        {
            _exerciseOverButtonText = value;
            OnPropertyChanged("exerciseOverButtonText");
        }
    }

    public SessionPageViewModel(MainWindow _mainWindow)
    {
        mainWindow = _mainWindow;
        currentState = new ExerciseState(mainWindow.session.exercises[currentExerciseIndex], currentExerciseIndex);
        currentState.CurrentExerciseIndexChanged += NextExerciseHandler;
        timer = new TimerController(this);
        InitializeFields();
    }

    private void InitializeFields()
    {
        ExerciseName = mainWindow.session.exercises[currentExerciseIndex].Name;
        ExerciseDesc = mainWindow.session.exercises[currentExerciseIndex].Description;
        exerciseOverButtonText = "Passer au prochain exercice";
        Timer = "00:00";
    }

    private void UpdateTextFields()
    {
        if (currentState is ExerciseState)
        {
            Timer = "00:00";
            exerciseOverButtonText = "Exercice terminé !";
            ExerciseName = mainWindow.session.exercises[currentExerciseIndex].Name;
            ExerciseDesc = mainWindow.session.exercises[currentExerciseIndex].Description;
        }
        else if (currentState is RestState)
        {
            Timer = mainWindow.session.restTime.getFormatDuration();
            if (currentExerciseIndex < mainWindow.session.exercises.Count)
            {
                exerciseOverButtonText = "Passer au prochain exercice";
                ExerciseName = "Repos";
                ExerciseDesc = "Prenez ce temps pour vous reposer !";
            }
            else
            {
                exerciseOverButtonText = "Terminer la séance";
                ExerciseName = "Repos";
                ExerciseDesc = "Dernier repos ! N'oubliez pas de vous ettirez après la séance !";
            }
        }
    }

    public void Timer_Tick(object sender, EventArgs e)
    {
        if (currentState is ExerciseState)
        {
            Timer = timer.currentTimeElapsed.ToString(@"mm\:ss");
        }
        else if (currentState is RestState)
        {
            TimeSpan restDuration = TimeSpan.FromSeconds(mainWindow.session.restTime.getDurationInSecond());
            TimeSpan remainingRestTime = restDuration - timer.currentTimeElapsed;
            Timer = remainingRestTime.ToString(@"mm\:ss");
            if (timer.currentTimeElapsed >= restDuration)
            {
                if (currentExerciseIndex < mainWindow.session.exercises.Count)
                {
                    ChangeState(new ExerciseState(mainWindow.session.exercises[currentExerciseIndex], currentExerciseIndex));
                }
                else
                {
                    EndSession();
                }
            }
        }
    }

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
        currentExerciseIndex = newIndex;
    }

    public void EndSession()
    {
        timer.Stop();
        MessagesBox.InfosBox("Séance terminée !");
        mainWindow.Close();
    }

    public void NextButton()
    {
        if (currentState is ExerciseState)
        {
            if (currentExerciseIndex < mainWindow.session.exercises.Count)
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
            if (currentExerciseIndex < mainWindow.session.exercises.Count)
            {
                ChangeState(new ExerciseState(mainWindow.session.exercises[currentExerciseIndex], currentExerciseIndex));
            }
            else
            {
                EndSession();
            }
        }
    }
}
