using System.Windows;

namespace GymGenius.Utilities
{
    internal class MessagesBox
    {
        public static bool WarnUser(string text)
        {
            MessageBoxResult result = MessageBox.Show(text, "Attention", MessageBoxButton.OK);
            return result == MessageBoxResult.Yes;
        }

        public static void InfosBox(string text)
        {
            MessageBox.Show(text);
        }

        public static bool ShowYesNoMessageBox(string message, string caption)
        {
            MessageBoxResult result = MessageBox.Show(message, caption, MessageBoxButton.YesNo, MessageBoxImage.Question);
            return result == MessageBoxResult.Yes;
        }
    }
}
