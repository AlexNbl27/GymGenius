using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        // Add a DependencyProperty for BorderColor
        public static readonly DependencyProperty BorderColorProperty = DependencyProperty.Register(
            "BorderColor", typeof(Brush), typeof(ExerciseComponent), new PropertyMetadata(Brushes.Black));

        public Brush BorderColor
        {
            get => (Brush)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        // Handle MouseDown event
        private void ExerciseComponent_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BorderColor = Brushes.Blue; // Change border color to blue
        }

        // Handle MouseUp event
        private void ExerciseComponent_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BorderColor = Brushes.Black; // Change border color back to black
        }
    }
}
