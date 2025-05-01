using System;

namespace DungeonExplorer
{
    /// <summary>
    /// A class representing a weapon in the text-based adventure.
    /// </summary>
    public class Weapon : Item, IUsable
    {
        public int attackDamage;
        public string attackType;

        /// <summary>
        /// Initializes a new instance of the <see cref="Weapon"/> class.
        /// </summary>
        /// <param name="name">The name of the weapon.</param>
        /// <param name="damage">The attack damage of the weapon.</param>
        public Weapon(string name, int damage) : base(name)
        {
            this.attackDamage = damage;
        }

        /// <summary> Gets the weapon's attack type. </summary>
        public string GetAttackType()
        {
            return this.attackType;
        }

        /// <summary> Gets the weapon's attack damage. </summary>
        public int GetDamage()
        {
            return this.attackDamage;
        }
    }
}