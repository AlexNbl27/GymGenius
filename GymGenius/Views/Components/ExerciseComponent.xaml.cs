using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GymGenius.Views.Components
{
    public partial class ExerciseComponent : UserControl
    {
        public static readonly DependencyProperty ExerciseNameProperty =
            DependencyProperty.Register("ExerciseName", typeof(string), typeof(ExerciseComponent));

        public static readonly DependencyProperty ExerciseDescriptionProperty =
            DependencyProperty.Register("ExerciseDescription", typeof(string), typeof(ExerciseComponent));

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
            Border.Background = Brushes.Black;
        }
    }
}
