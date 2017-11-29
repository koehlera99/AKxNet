using System.Diagnostics;
using System.Windows;

namespace TCS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //FantasyBattle.MonoGame game;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //btnFantasyBattle.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            //btnHelix.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            
        }

        private void btnFantasyBattle_Click(object sender, RoutedEventArgs e)
        {
            WPF.Map m = new WPF.Map();
            m.Show();
        }

        private void btnMap3D_Click(object sender, RoutedEventArgs e)
        {
            WPF.Map3D m = new WPF.Map3D();
            m.Show();
        }


        private void btnMonoGame_Click(object sender, RoutedEventArgs e)
        {
            //this.Close();
            //using (var g = new TileEngine.Game1())
            //    g.Run();

            //this.Close();
            //game = new FantasyBattle.MonoGame();
            //game.Run();

            //this.Close();
            this.Close();

            //TileEngine.Game1 g = new TileEngine.Game1();
            //g.Run();


            //FantasyBattle.MonoGame mg = new FantasyBattle.MonoGame();
            //mg.Run();






        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //game.Exit();

        }

        private void btnSpaceBattle_Click(object sender, RoutedEventArgs e)
        {
            Space.Map m = new Space.Map();
            m.Show();
        }

        private void btnMud_Click(object sender, RoutedEventArgs e)
        {


            WPF.MudInterface m = new WPF.MudInterface();
            m.Show();
            this.Close();
        }

        private void btnLevelsDeep_Click(object sender, RoutedEventArgs e)
        {
            //txtLevelsDeep.Text = Crafting.Scarcity.LevelsDeep(0).ToString();
        }

        private void btnServerHost_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("..\\..\\..\\TacticalCombatSuiteServer\\bin\\Debug\\TacticalCombatSuiteServer.exe");

            //Server.ServerInterface f = new Server.ServerInterface();
            //f.Show();
        }

        private void btnSharpDX_Click(object sender, RoutedEventArgs e)
        {
            //SharpDXTesting.SharpDXWindow w = new SharpDXTesting.SharpDXWindow();
            //w.Show();
        }

        private void btnHelix_Click(object sender, RoutedEventArgs e)
        {
            WPF.HelixMap h = new WPF.HelixMap();
            h.Show();

            //this.Close();
        }

        private void LoadSlimDX_Click(object sender, RoutedEventArgs e)
        {
            //SlimDXTesting.Start();
        }

        private void btnSpawnClient_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("TacticalCombatSuite.exe");
            Process.Start("TacticalCombatSuite.exe");
            Process.Start("TacticalCombatSuite.exe");

            this.Hide();
        }

        private void btnOpenWorld_Click(object sender, RoutedEventArgs e)
        {
            Platformer.OpenWorld w = new Platformer.OpenWorld();
            w.Show();
            this.Close();
        }
    }
}
