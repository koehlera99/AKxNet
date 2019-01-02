using System.Windows;
using System.Windows.Controls;
using UrhoSharp.Wpf.Apps;

namespace UrhoSharp.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for DirectionPanel.xaml
    /// </summary>
    public partial class DirectionPanel : UserControl
    {
        public DirectionPanel()
        {
            InitializeComponent();
        }

        private void MoveForwardButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MoveCharacter("F");
        }

        private void MoveBackButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MoveCharacter("B");
        }

        private void MoveRightButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MoveCharacter("R");
        }

        private void MoveLeftButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MoveCharacter("L");
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MoveCharacter("U");
        }

        private void MoveDown_Click(object sender, RoutedEventArgs e)
        {
            Navigation.MoveCharacter("D");
        }
    }
}
