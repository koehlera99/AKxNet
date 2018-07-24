using System.Windows.Controls;
using System.Windows.Media.Animation;
using RPG.Standard.Units;

namespace UrhoSharp.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for ResourceBar.xaml
    /// </summary>
    public partial class ResourceBar : UserControl
    {
        private int currentHP;
        private int currentPower;
        private int currentMagic;
        private int currentEnergy;

        private int maxHP;
        private int maxPower;
        private int maxMagic;
        private int maxEnergy;

        private BasicUnit _unit;

        public int MaxHP
        {
            get
            {
                return maxHP;
            }
            set
            {
                maxHP = value;
                HPBar.Maximum = maxHP;
                HPBar.Value = maxHP - currentHP;
            }
        }

        public int MaxPower
        {
            get
            {
                return maxPower;
            }
            set
            {
                maxPower = value;
                PowerBar.Maximum = maxPower;
                PowerBar.Value = maxPower - currentPower;
            }
        }

        public int MaxMagic
        {
            get
            {
                return maxMagic;
            }
            set
            {
                maxMagic = value;

                MagicBar.Maximum = maxMagic;
                MagicBar.Value = maxMagic - currentMagic;
            }
        }

        public int MaxEnergy
        {
            get
            {
                return maxEnergy;
            }
            set
            {
                maxEnergy = value;

                EnergyBar.Maximum = maxEnergy;
                EnergyBar.Value = maxEnergy - currentEnergy;
            }
        }

        public int HP
        {
            get
            {
                return currentHP;
            }
            set
            {
                currentHP = value;
                this.lblHP.Content = "HP: " + currentHP.ToString() + " / " + MaxHP.ToString();

                //this.HPBar.Value = maxHP - currentHP;


                this.HPBar.Value = currentHP;

                if (HPBar.Value < 0)
                {
                    HPBar.Value = 0;
                    Storyboard sb = (Storyboard)FindResource("sbProg");
                    sb.Begin(this);
                }


                //this.HPBar.Value = maxHP;
                //this.HPBar.Value -= 10;

            }
        }

        public int Power
        {
            get
            {
                return currentPower;
            }
            set
            {
                currentPower = value;
                this.lblPower.Content = "Power: " + currentPower.ToString() + " / " + maxPower.ToString();
                this.PowerBar.Value = currentPower;
            }
        }

        public int Magic
        {
            get
            {
                return currentMagic;
            }
            set
            {
                currentMagic = value;
                this.lblMagic.Content = "Magic: " + currentMagic.ToString() + " / " + maxMagic.ToString();
                this.MagicBar.Value = currentMagic;
            }
        }

        public int Energy
        {
            get
            {
                return currentEnergy;
            }
            set
            {
                currentEnergy = value;
                this.lblEnergy.Content = "Energy: " + currentEnergy.ToString() + " / " + maxEnergy.ToString();
                this.EnergyBar.Value = currentEnergy;
            }
        }

        public ResourceBar()
        {
            InitializeComponent();
        }

        public ResourceBar(BasicUnit unit)
        {
            InitializeComponent();

            Unit = unit;
        }

        public BasicUnit Unit
        {
            get
            {
                return _unit;
            }

            set
            {
                _unit = value;
                RefreshResourceBar();
            }
        }

        public void RefreshResourceBar()
        {
            this.MaxHP = _unit.MaxHp;
            this.HP = _unit.CurrentHp;

            this.MaxPower = _unit.MaxPower;
            this.Power = _unit.CurrentPower;

            this.MaxMagic = _unit.MaxMagic;
            this.Magic = _unit.CurrentMagic;

            this.MaxEnergy = _unit.MaxEnergy;
            this.Energy = _unit.CurrentEnergy;
        }


        


    }
}
