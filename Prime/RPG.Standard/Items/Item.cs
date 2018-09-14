using RPG.Standard.Effects;
using System.Collections.Generic;
using System.Linq;

namespace RPG.Standard.Items
{
    public class Item : Object
    {
        public float Size { get; set; }
        public float Weight { get; set; }

        public short ChanceToFind { get; set; }
        public bool IsEquiped { get; set; }
        public bool IsContainter { get; set; }
        public bool IsTwoHanded { get; set; } = false;

        public int HP { get; set; } = 10;
        public int Energy { get; set; } = 0;

        public IEnumerable<Ability> Abilities { get; set; }
        public IEnumerable<Property> Properties { get; set; }
        public IEnumerable<Material> Materials { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public WeaponSlots WeaponLocation { get; set; } = WeaponSlots.PrimaryHand;

        public Item()
        {
            Size = 0;
            Weight = 0;

            Materials = new List<Material>();
            Properties = new List<Property>();
        }

        public Item(int Id, string itemName, float size, float weight, bool iscontainer,
            int hp, int energy, List<PhysicalElement> elements, List<Property> properties)
        {
            Size = size;
            Weight = weight;

            Materials = new List<Material>();
            Properties = new List<Property>();
        }

        public void UseAbility(int ablitiyId)
        {
            if (Abilities.Count() > 0)
            {
                var abilities =
                    from ability in Abilities
                    where ability.Id == ablitiyId
                    select ability;

                foreach (var a in abilities)
                {
                    a.AbilityFunction.Invoke(new List<AbilityArgs>() { new AbilityArgs(this) });
                }
            }
        }
    }
}
