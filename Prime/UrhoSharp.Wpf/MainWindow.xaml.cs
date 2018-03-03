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
            var app = await UrhoSurface.Show<MyApp>(new Urho.ApplicationOptions("MyData"));
        }
    }
}
