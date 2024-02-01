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
    }
}
