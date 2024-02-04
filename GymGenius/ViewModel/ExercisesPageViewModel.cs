using GymGenius.Models;
using GymGenius.ModelView;
using GymGenius.Utilities;
using GymGenius.Views;
using System.Windows.Input;

namespace GymGenius.ViewModels
{
    public class ExercisesPageViewModel : ViewModelBase
    {
        private readonly MainWindow mainWindow;
        private readonly ExercisesPageLogic exercisesPageLogic = new();
        private List<AExercise> exercises;

        public bool IsBackChecked { get; set; }
        public bool IsLegChecked { get; set; }
        public bool IsArmChecked { get; set; }
        public bool IsShoulderChecked { get; set; }
        public bool IsTrunkChecked { get; set; }
        public bool IsCardioChecked { get; set; }
        public bool IsMuscularChecked { get; set; }
        public string NumericTextBox { get; set; }

        public List<AExercise> Exercises
        {
            get { return exercises; }
            set
            {
                exercises = value;
                OnPropertyChanged("Exercises");
            }
        }

        public ICommand CreateSessionCommand { get; }
        public ICommand SearchCommand { get; }

        public ExercisesPageViewModel(MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            Exercises = exercisesPageLogic.GetAllExercises();

            CreateSessionCommand = new RelayCommand(CreateSession);
            SearchCommand = new RelayCommand(OnSearchClick);
        }

        private void CreateSession(object obj)
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

        private void OnSearchClick(object obj)
        {
            Exercises.Clear();
            List<AExercise> tmp = [];

            tmp = IsBackChecked || IsLegChecked || IsArmChecked || IsShoulderChecked || IsTrunkChecked || !string.IsNullOrEmpty(NumericTextBox) || IsCardioChecked || IsMuscularChecked
                ? !string.IsNullOrEmpty(NumericTextBox)
                    ? exercisesPageLogic.GetFilteredExercises(IsLegChecked, IsArmChecked, IsBackChecked, IsShoulderChecked, IsTrunkChecked, IsCardioChecked, IsMuscularChecked, int.Parse(NumericTextBox))
                    : exercisesPageLogic.GetFilteredExercises(IsLegChecked, IsArmChecked, IsBackChecked, IsShoulderChecked, IsTrunkChecked, IsCardioChecked, IsMuscularChecked)
                : exercisesPageLogic.GetAllExercises();

            mainWindow.NavigateToPage(new ExercisesPage(mainWindow, tmp));
        }

        public void AddExercise(AExercise exercise)
        {
            mainWindow.session.exercises.Add(exercise);
        }
    }
}
