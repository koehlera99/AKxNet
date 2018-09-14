using RPG.Standard.Items.Offense;
using RPG.Standard.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UrhoSharp.Wpf
{
    /// <summary>
    /// Interaction logic for StatPanel.xaml
    /// </summary>
    public partial class StatPanel : UserControl
    {
        Unit player;
        Unit target;
        Weapon weapon = new Weapon();

        private bool player1 = true;

        public StatPanel()
        {
            InitializeComponent();
            InitializeUnits();

        }

        private void InitializeUnits()
        {
            player = new Unit
            (
                new int[] { 12, 14, 14, 11, 10, 11 },
                new int[] { 12, 14, 14, 11, 10, 11, 12, 14, 14, 11, 10, 11, 20, 24, 12, 14 },
                new int[] { 34, 23, 50, 25, 0, 0, 0 },
                new int[] { 14, 14, 11, 10, 11, 12, 14, 14, 11, 10, 11, 20, 24 },
                new int[] { 34, 23, 50, 25, 12, 47, 14 },
                new int[] { 34, 23, 50 }
            );

            target = new Unit
            (
                new int[] { 52, 25, 12, 47, 5, 11 },
                new int[] { 25, 44, 12, 18, 50, 41, 12, 14, 14, 11, 10, 11, 20, 24, 12, 14 },
                new int[] { 34, 23, 50, 25, 0, 0, 0 },
                new int[] { 14, 14, 11, 10, 11, 12, 14, 14, 11, 10, 11, 20, 24 },
                new int[] { 34, 23, 50, 25, 12, 47, 14 },
                new int[] { 34, 23, 50 }
            );

            MyLevels.Unit = player;
            TargetLevels.Unit = target;
        }

        public void Attack()
        {
            if (player1)
                player.PerformMeleeAttack(target, weapon);
            else
                target.PerformMeleeAttack(player, weapon);

            player1 = !player1;

            MyLevels.RefreshResourceBar();
            TargetLevels.RefreshResourceBar();

            //MyLevels.Unit = player;
            //TargetLevels.Unit = target;
        }
    }
}
