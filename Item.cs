using System;
using System.Runtime.CompilerServices;

/// <summary>
///
/// </summary>
namespace DungeonExplorer
{
    public class Item
    {
        private string name;
        private string description;

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        public Item(string name)
        {
            this.name = name;
        }

        public string GetDescription()
        {
            return this.description;
        }

    }

    public class Potion : Item
    {
        public int hpEffect;

        /// <summary>
        /// Initializes a new instance of the <see cref="Potion"/> class.
        /// </summary>
        /// <param name="name">The name of the potion.</param>
        /// <param name="effect">The HP effect of the potion.</param>
        public Potion(string name, int effect) : base(name)
        {
            this.hpEffect = effect;
        }

        public int GetHpEffect()
        {
            return this.hpEffect;
        }

       

        public class Weapon : Item
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

            public string GetAttackType()
            {
                return this.attackType;
            }

            public int GetDamage()
            {
                return this.attackDamage;
            }
        }
    }
}


