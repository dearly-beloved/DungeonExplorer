using System;
using System.Runtime.CompilerServices;

namespace DungeonExplorer
{
    interface IConsumable
    {
        int GetHpEffect();
    }

    public class Item
    {
        private string name;
        private string tag;

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        public Item(string name)
        {
            this.name = name;
        }

    }

    public class Potion : Item, IConsumable
    {
        public int hpEffect;
        private string tag;

        /// <summary>
        /// Initializes a new instance of the <see cref="Potion"/> class.
        /// </summary>
        /// <param name="name">The name of the potion.</param>
        /// <param name="effect">The HP effect of the potion.</param>
        public Potion(string name, int effect) : base(name)
        {
            this.hpEffect = effect;
        }

        /// <summary> Gets the potion's HP effect. </summary>
        public int GetHpEffect()
        {
            return this.hpEffect;
        }

    interface IUsable
    {
        int GetDamage();
    }

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
}


