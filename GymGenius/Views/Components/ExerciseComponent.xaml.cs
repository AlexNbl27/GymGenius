using System.Windows;
using System.Windows.Controls;

namespace GymGenius.Views.Components
{
    public partial class ExerciseComponent : UserControl
    {
        // Dependency properties for binding data
        public static readonly DependencyProperty ExerciseNameProperty =
            DependencyProperty.Register("ExerciseName", typeof(string), typeof(ExerciseComponent));

        public static readonly DependencyProperty ExerciseDescriptionProperty =
            DependencyProperty.Register("ExerciseDescription", typeof(string), typeof(ExerciseComponent));

        // Properties for accessing the dependency properties
        public string ExerciseName
        {
            get { return (string)GetValue(ExerciseNameProperty); }
            set { SetValue(ExerciseNameProperty, value); }
        }

        public string ExerciseDescription
        {
            get { return (string)GetValue(ExerciseDescriptionProperty); }
            set { SetValue(ExerciseDescriptionProperty, value); }
        }

        public ExerciseComponent()
        {
            InitializeComponent();
            // You can add additional initialization code here if needed
        }

        // Method to update ExerciseName
        public void UpdateExerciseName()
        {
            ExerciseNameTextBlock.Text = ExerciseName;
        }

        // Method to update ExerciseDescription
        public void UpdateExerciseDescription()
        {
            //ExerciseDescriptionTextBlock.Text = ExerciseDescription;
        }
    }
}
