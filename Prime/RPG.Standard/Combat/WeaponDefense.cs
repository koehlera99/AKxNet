using RPG.Standard.Base;
using RPG.Standard.Items.Offense;
using RPG.Standard.Units;

namespace RPG.Standard.Combat
{
    public class WeaponDefense : Defense
    {
        public WeaponDefense(WeaponAttack attack) 
            : base(attack)
        {
            WeaponUsed = attack.WeaponUsed;

            BlockRoll = Tools.Roll.D100;
            DodgeRoll = Tools.Roll.D100;
        }

        public Weapon WeaponUsed { get; }

        public int BlockRoll { get; }
        public int DodgeRoll { get; }

        public int BlockDefenseValue => BlockRoll <= Attack.Defender.Stats.BlockChance.Value ? Attack.Defender.Stats.BlockBonus.Value : 0;
        public int DodgeDefenseValue => DodgeRoll <= Attack.Defender.Stats.DodgeChance.Value ? Attack.Defender.Stats.DodgeBonus.Value : 0;

        public int WeaponDamageTypeResistance
        {
            get
            {
                switch (WeaponUsed.DamageType)
                {
                    case WeaponDamageType.Piercing:
                        return Attack.Attacker.Stats.PierceResist.Value;
                    case WeaponDamageType.Slashing:
                        return Attack.Attacker.Stats.SlashResist.Value;
                    case WeaponDamageType.Blunt:
                        return Attack.Attacker.Stats.BluntResist.Value;
                    default:
                        return 0;
                }
            }
        }
    }
}
