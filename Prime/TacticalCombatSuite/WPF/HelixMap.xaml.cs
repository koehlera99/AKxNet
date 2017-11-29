using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;
using TCS.FantasyBattle;
using TCS.Net;


namespace TCS.WPF
{
    /// <summary>
    /// Interaction logic for HelixMap.xaml
    /// </summary>
    public partial class HelixMap : Window
    {
        public HelixMap()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnRemoveModelClick(object sender, RoutedEventArgs e)
        {
            BattleGrid.Battle3DViewPort.Children.Remove(BattleGrid.UnitModel);
        }

        private void btnAddModel_Click(object sender, RoutedEventArgs e)
        {
            BattleGrid.Battle3DViewPort.Children.Add(BattleGrid.UnitModel);
        }

        private void btnAddSphere_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();

            Players.UnitSpheres.Add(Guid.NewGuid(), new SphereVisual3D());
            Players.UnitSpheres.Last().Value.Center = new Point3D(r.Next(0, 20), r.Next(0, 20), 2);
            Players.UnitSpheres.Last().Value.Fill = Brushes.DarkOrange;
            Players.UnitSpheres.Last().Value.Radius = 0.5;
            BattleGrid.Battle3DViewPort.Children.Add(Players.UnitSpheres.Last().Value);
        }

        private void btnRemoveSphere_Click(object sender, RoutedEventArgs e)
        {
            if(Players.UnitSpheres.Count > 0)
            {
                BattleGrid.Battle3DViewPort.Children.Remove(Players.UnitSpheres.Last().Value);
                Players.UnitSpheres.Remove(Players.UnitSpheres.Last().Key);
            }
        }
    }
}
