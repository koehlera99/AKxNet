using System.Threading.Tasks;
using System.Windows;
using RPG.Standard.Items.Offense;
using RPG.Standard.Units;
using UrhoSharp.Wpf.Apps;

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
            InitializeUnits();
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
            //Navigation.PerformAction();
        }

        private void InitializeUnits()
        {
            player = new BasicUnit(200, 100, 50, 25);
            target = new BasicUnit(150, 50, 200, 50);

            MyLevels.Unit = player;
            TargetLevels.Unit = target;
        }

        BasicUnit player;
        BasicUnit target;
        Weapon weapon = new Weapon();

        private bool player1 = true;

        private void Attack_Click(object sender, RoutedEventArgs e)
        {
            if (player1)
                player.PerformAttack(target, weapon);
            else
                target.PerformAttack(player, weapon);

            player1 = !player1;

            MyLevels.RefreshResourceBar();
            TargetLevels.RefreshResourceBar();

            //MyLevels.Unit = player;
            //TargetLevels.Unit = target;
        }

        private void Heal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DirectionPanel_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigation.AddAndDropSpheres();
        }
    }
}
