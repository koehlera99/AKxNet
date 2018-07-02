using System.Threading.Tasks;
using System.Windows;

namespace UrhoSharp.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var app = await UrhoSurface.Show<Navigation>(new Urho.ApplicationOptions("MyData"));
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

        private void ActionButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.PerformAction();
        }
    }
}
