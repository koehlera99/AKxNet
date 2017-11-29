using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using TCS.Net;
using TCS.RPG.Items;
using TCS.RPG.Tools;
using TCS.RPG.Units;



namespace TCS.WPF
{
    /// <summary>
    /// Interaction logic for MudInterface.xaml
    /// </summary>



    public partial class MudInterface : Window
    {
        private string uri = "net.tcp://localhost:22222/TCSService";

        private Unit player;
        private Unit SelectedDefender;

        private List<Unit> ListOfDefenders;

        //InstanceContext tcsServiceCallbackHandler = new InstanceContext(new TcsServiceCallbackHandler());
        //TCSServiceReference.TCSServiceClient Client;

        //public Guid ClientID { get; private set; }
        //public string ClientName { get; private set; }

        public MudInterface()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateTestSituation();
            FillPlayerInfo();
        }

        public void CreateTestSituation()
        {
            player = new RPG.Units.Unit();
            player.Strength = 15;
            player.Dexterity = 12;
            player.Constitution = 12;
            player.Wisdom = 10;
            player.Intelligence = 8;
            player.Charisma = 8;


            RPG.Items.Weapon w = new RPG.Items.Weapon(5, 5, "Basic Weapon");
            w.WeaponLocation = RPG.Items.WeaponSlots.PrimaryHand;

            RPG.Items.Weapon w2 = new RPG.Items.Weapon(5, 5, "Smasher");
            w2.WeaponLocation = RPG.Items.WeaponSlots.OffHand;

            RPG.Items.Weapon w3 = new RPG.Items.Weapon(5, 5, "Slasher");
            w3.WeaponLocation = RPG.Items.WeaponSlots.OffHand | RPG.Items.WeaponSlots.PrimaryHand;

            w2.Energy = 50;

            player.EquipWeapon(w);
            player.EquipWeapon(w2);
            player.EquipWeapon(w3);
            player.EquipWeapon(w);
            player.EquipWeapon(w2);
            player.EquipWeapon(w);
            player.EquipWeapon(w2);

            w3.WeaponRestriction = WeaponSlotRestriction.TwoHandedOnly;
            player.EquipWeapon(w3, WeaponSlots.OffHand);
            player.EquipWeapon(w2, WeaponSlots.PrimaryHand);

            //player.AddEffect("Strength", 10, "Potion of giant _strength", string.Empty, 25);
            //player.AddEffect(new RPG.Effects.Effect("Strength", 100, "Test", "", 10));
            //player.AddEffect(new RPG.Effects.Effect("Wisdom", 100, "Test", "", 5));

            player.HitDice = 10;
            player.Experience = 50000;

            player.HitPoints = player.MaxHitPoints;
            player.Power = player.MaxPower;
            player.Magic = player.MaxMagic;
            player.Energy = player.MaxEnergy;

            MyLevels.Unit = player;


            //Create a list of Defenders
            ListOfDefenders = new List<Unit>();

            for (int i = 0; i < 5; i++)
            {
                Unit unit = new Unit();

                unit.UnitName = "BZ-" + (i * 5).ToString();
                unit.Strength = i + 10;
                unit.Dexterity = i + 12;
                unit.Constitution = i + 10;
                unit.Wisdom = i + 10;
                unit.Intelligence = i + 8;
                unit.Charisma = i + 18;

                unit.HitDice = 8;
                unit.Experience = 4000;

                unit.HitPoints = unit.MaxHitPoints;
                unit.Power = unit.MaxPower;
                unit.Magic = unit.MaxMagic;
                unit.Energy = unit.MaxEnergy;

                ListOfDefenders.Add(unit);
            }

            SelectedDefender = ListOfDefenders[0];
            TargetLevels.Unit = SelectedDefender;

            lstDefenders.ItemsSource = ListOfDefenders;
            lstDefenders.DisplayMemberPath = "UnitName";
        }

        private void btnAttack_Click(object sender, RoutedEventArgs e)
        {
            RPG.Tools.Combat2 c = new RPG.Tools.Combat2();
            c.AttackDefense();

            try
            {
                Armor a = new Armor();
                a.Energy = 0;
                a.DefenseBonus = 3;
                a.ArmorType = ArmorTypes.Chain;
                a.ArmorHardness = HardnessScale.Silver;

                a.ArmorSlot = ArmorSlots.Body;
                player.EquipItem(a);

                a.ArmorType = ArmorTypes.Plate;
                a.ArmorSlot = ArmorSlots.Hands;
                player.EquipItem(a);

                a.ArmorSlot = ArmorSlots.Body;
                SelectedDefender.EquipItem(a);

                a.ArmorSlot = ArmorSlots.Head;
                SelectedDefender.EquipItem(a);


                int blunt = SelectedDefender.BluntResist;

                int energy = player.MaxEnergy;

                Weapon w = (Weapon)player.EquipedWeapons[WeaponSlots.PrimaryHand];
                string attackString;
                int damage;

                damage = Combat.AttackUnit(player, SelectedDefender, w);

                if (damage == 0)
                    attackString = "The attack missed!";
                else
                    attackString = "The attack hit and dealt: " + damage.ToString() + " damage!";






                PrintToScreen(attackString, Brushes.Red);
                //rtxtCommandLineOutput.AppendText(attackString);

                //if(NetManager.Client != null)
                //    NetManager.Client.BroadcastMessage(Players.Client, attackString);






                TargetLevels.HP = SelectedDefender.HitPoints;

                //TargetLevels.lblHP.Content = "HP: " + SelectedDefender.HitPoints.ToString() + " / " + SelectedDefender.MaxHitPoints.ToString();
                ////DefenderHPBar.Value += damage;

                //TargetLevels.HPBar.Value = SelectedDefender.MaxHitPoints - SelectedDefender.HitPoints;

                ////Storyboard sb = (Storyboard)FindResource("sbProg");

                //if (DefenderHPBar.Value >= SelectedDefender.MaxHitPoints)
                //{
                //    DefenderHPBar.Value = SelectedDefender.MaxHitPoints;
                //    Storyboard sb = (Storyboard)FindResource("sbProg");
                //    sb.Begin(this);

                //    //DefenderHPBar.BeginAnimation(DefenderHPBar.Value, )


                //}


                //Command.Execute.Attack(player, SelectedDefender, new RPG.Items.Weapon());

                //player.RefreshEffects();
                //string effectsString = string.Empty;

                //if(player.CurrentEffects.Count == 0)
                //    rtxtCommandLineOutput.AppendText("No Current Effects" + "\r");
                //else
                //{
                //    foreach (RPG.Effects.Effect effect in player.CurrentEffects)
                //    {
                //        effectsString += "Effect: " + effect.Name + ": " + effect.Description + "TTL: " + effect.TTL.ToString() + "\r";
                //    }
                //}

                //rtxtCommandLineOutput.AppendText(effectsString);
                rtxtCommandLineOutput.ScrollToEnd();

                FillPlayerInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FillPlayerInfo()
        {
            if (player != null)
            {
                txtStr.Text = player.Strength.ToString();
                txtDex.Text = player.Dexterity.ToString();
                txtCon.Text = player.Constitution.ToString();
                txtWis.Text = player.Wisdom.ToString();
                txtInt.Text = player.Intelligence.ToString();
                txtCha.Text = player.Charisma.ToString();

                //List current effectsString

                foreach (RPG.Effects.Effect effect in player.CurrentEffects)
                {
                    txtEffects.Text += "Effect: " + effect.Name + ": " + effect.Description + "\n";
                }
            }
        }

        private void DefenderHPBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //if (e.NewValue > 38)
            //{
            //    //DefenderHPBar.Tag = "Low";

            //    //Storyboard sb = (Storyboard)FindResource("sbProg");
            //    //sb.Begin(this);
            //}
            //else
            //    DefenderHPBar.Tag = string.Empty;

            //if (e.NewValue > 10)
            //{
            //    var switchOffAnimation = new DoubleAnimation
            //    {
            //        To = 0,
            //        Duration = TimeSpan.FromSeconds(1)
            //    };

            //    var switchOnAnimation = new DoubleAnimation
            //    {
            //        To = 3,
            //        Duration = TimeSpan.FromSeconds(1),
            //        BeginTime = TimeSpan.FromSeconds(0.5)
            //    };

            //    var blinkStoryboard = new Storyboard
            //    {
            //        Duration = TimeSpan.FromSeconds(0.5),
            //        RepeatBehavior = RepeatBehavior.Forever,
            //        Name = "Blinkx"
            //    };

            //    Storyboard.SetTargetName(blinkStoryboard, "Blinkx");

            //    Storyboard.SetTarget(switchOffAnimation, DefenderHPBar);
            //    Storyboard.SetTargetProperty(switchOffAnimation, new PropertyPath(ProgressBar.OpacityProperty));
            //    blinkStoryboard.Children.Add(switchOffAnimation);

            //    Storyboard.SetTarget(switchOnAnimation, DefenderHPBar);
            //    Storyboard.SetTargetProperty(switchOnAnimation, new PropertyPath(ProgressBar.OpacityProperty));
            //    blinkStoryboard.Children.Add(switchOnAnimation);

            //    DefenderHPBar.BeginStoryboard(blinkStoryboard, HandoffBehavior.SnapshotAndReplace, true);


            //}
            //else
            //{
            //    if (e.OldValue > 10)
            //    {
            //        //this.DefenderHPBar.BeginStoryboard(null);

            //        //Storyboard blinkStoryBoard = (Storyboard)this.FindName("Blinkx");


            //        //blinkStoryBoard.Stop();
            //    }

            //}
        }

        private void btnHeal_Click(object sender, RoutedEventArgs e)
        {
            SelectedDefender.HitPoints += 10;
            TargetLevels.HP = SelectedDefender.HitPoints;

            //SelectedDefender.HitPoints += 10;
            //TargetLevels.lblHP.Content = "HP: " + SelectedDefender.HitPoints.ToString() + " / " + SelectedDefender.MaxHitPoints.ToString();
            // DefenderHPBar.Value -= 10;

            //DefenderHPBar.Value = SelectedDefender.HitPoints;
            //TargetLevels.HPBar.Value = SelectedDefender.MaxHitPoints - SelectedDefender.HitPoints;

            //Storyboard sb = (Storyboard)FindResource("sbProg");

            //if (TargetLevels.HPBar.Value < 0)
            //{
            //    TargetLevels.HPBar.Value = 0;
            //    Storyboard sb = (Storyboard)FindResource("sbProg");
            //    sb.Begin(this);

            //    //DefenderHPBar.BeginAnimation(DefenderHPBar.Value, )


            //}
        }

        private void btnLevelsDeep_Click(object sender, RoutedEventArgs e)
        {
            double CritChance;
            double CritRate;

            if (!double.TryParse(txtCritChance.Text, out CritChance))
                CritChance = 15;

            if (!double.TryParse(txtCritRate.Text, out CritRate))
                CritRate = 15;


            double dmg = 10;
            double total = 0;

            for (int i = 0; i < 100; i++)
            {
                if (i < CritChance)
                    total += dmg + (dmg * (CritRate / 100));
                else
                    total += dmg;
            }

            PrintToScreen(total.ToString());
            return;



            int numLoops = 1000;
            int levels = 1;

            for (levels = 1; levels <= 10; levels++)
            {
                System.Threading.Thread.Sleep(100);
                //rtxtCommandLineOutput.AppendText("Level " + levels.ToString() + ": " + Crafting.Scarcity.LevelsDeep(levels).ToString() + "\r");
            }

            PrintToScreen("\r");
            //rtxtCommandLineOutput.AppendText("\r\r");
            rtxtCommandLineOutput.ScrollToEnd();


            //for (int i = 0; i < numLoops; i++)
            //    rtxtCommandLineOutput.AppendText(Crafting.Scarcity.LevelsDeep(ref levels).ToString());

            //rtxtCommandLineOutput.AppendText("Levels:")

        }

        private void btnJoin_Click(object sender, RoutedEventArgs e)
        {
            //NetManager.JoinServer(uri, txtCommandLine.Text);
            PrintToScreen("Joined as " + Players.Client.ClientName + " with client ID: " + Players.Client.ClientID.ToString());
        }



        public void PrintToScreen(string message)
        {
            PrintToScreen(message, (Brush)new BrushConverter().ConvertFrom("#FF45FF27"));
        }

        public void PrintToScreen(string message, Brush color)
        {
            TextRange tr = new TextRange(rtxtCommandLineOutput.Document.ContentEnd, rtxtCommandLineOutput.Document.ContentEnd);
            tr.Text = message + "\r";
            tr.ApplyPropertyValue(TextElement.ForegroundProperty, color);

            rtxtCommandLineOutput.ScrollToEnd();
            //rtxtCommandLineOutput.AppendText(message);
        }

        private void btnSendCommand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Random r = new Random();

                if (Players.Client.Units.Count == 0)
                    Players.CreateNewUnit();

                Players.Client.Units[0].Location = new UnitLocation
                {
                    X = r.Next(0, 20),
                    Y = r.Next(0, 20),
                    Z = r.Next(0, 20)
                };

                Command c = new Command();
                c.CommandName = "Move";
                c.Unit = Players.Client.Units[0];
                c.Sender = Players.Client;

                //NetManager.Client.BroadcastCommand(c);
                FantasyBattle.BattleGrid.MoveUnitSphere(Players.Client.Units[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending command: " + ex.Message, "Send Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                //if(NetManager.Client != null)
                //    NetManager.UnSubscribe();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error disconnecting from server: " + ex.Message, "Server Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad8:
                    MoveDirection(Direction.Up);
                    break;
                case Key.NumPad2:
                    MoveDirection(Direction.Down);
                    break;
                case Key.NumPad4:
                    MoveDirection(Direction.Left);
                    break;
                case Key.NumPad6:
                    MoveDirection(Direction.Right);
                    break;
            }
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            MoveDirection(Direction.Forward);
        }

        private void btnBackward_Click(object sender, RoutedEventArgs e)
        {
            MoveDirection(Direction.Backward);
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            MoveDirection(Direction.Right);
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            MoveDirection(Direction.Left);
        }
        private void btnDown_Click_1(object sender, RoutedEventArgs e)
        {
            MoveDirection(Direction.Down);
        }

        private void btnUp_Click_1(object sender, RoutedEventArgs e)
        {
            MoveDirection(Direction.Up);
        }

        private void MoveDirection(Direction direction)
        {
            try
            {
                switch (direction)
                {
                    case Direction.Forward:
                        Players.Client.Units[Players.Client.Units.Count - 1].Location.Y += 1;
                        break;
                    case Direction.Backward:
                        Players.Client.Units[Players.Client.Units.Count - 1].Location.Y -= 1;
                        break;
                    case Direction.Up:
                        Players.Client.Units[Players.Client.Units.Count - 1].Location.Z += 1;
                        break;
                    case Direction.Down:
                        Players.Client.Units[Players.Client.Units.Count - 1].Location.Z -= 1;
                        break;
                    case Direction.Left:
                        Players.Client.Units[Players.Client.Units.Count - 1].Location.X -= 1;
                        break;
                    case Direction.Right:
                        Players.Client.Units[Players.Client.Units.Count - 1].Location.X += 1;
                        break;
                    default:

                        break;
                }

                FantasyBattle.BattleGrid.MoveUnitSphere(Players.Client.Units[Players.Client.Units.Count - 1]);
                //return;

                //Random r = new Random();


                //Players.Unit.Location = new UnitLocation
                //{
                //    X = r.Next(0, 20),
                //    Y = r.Next(0, 20),
                //    Z = r.Next(0, 20)
                //};

                //Command c = new Command();
                //c.CommandName = "Move";
                //c.Unit = Players.Client.Units[0];
                //c.Sender = Players.Client;

                //NetManager.Client.BroadcastCommand(c);
                //FantasyBattle.BattleGrid.MoveUnitSphere(c.Sender);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending command: " + ex.Message, "Send Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void lstDefenders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedDefender = (Unit)(sender as ListBox).SelectedItem;

            if (SelectedDefender != null)
                TargetLevels.Unit = SelectedDefender;
        }

        private void btnAddUnit_Click(object sender, RoutedEventArgs e)
        {
            FantasyBattle.BattleGrid.AddNewUnitSphere(Players.CreateNewUnit());
        }


    }

    enum Direction
    {
        Forward,
        Backward,
        Up,
        Down,
        Left,
        Right
    }
}
