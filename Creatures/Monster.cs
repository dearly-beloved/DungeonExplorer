using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

/// <summary>
/// 
/// </summary>
namespace DungeonExplorer
{

    /// <summary> A class representing a creature in the text-based adventure. </summary>
    public class Monster : Creature, IFightable, IDamageable
    {
        protected int damage;
        private readonly Random rnd = new Random();
        protected string attackType;
        protected int xpGranted;

        /// <summary> Creates a new instance of the <see cref="Monster"/> class.
        /// Sets specific damage, health, attackType, xpGranted attributes
        /// based on the type of monster. </summary>
        /// <param name="name"> The name of the monster. </param>
        public Monster(string name) : base(name)
        {
            if (this.name == "Rotling")
            {
                this.damage = rnd.Next(1, 5);
                this.health = 4;
                this.attackType = "Blood Frenzy";
                this.xpGranted = rnd.Next(1, 3);
            }
            else if (this.name == "Cryptseer Mage")
            {
                this.damage = rnd.Next(2, 6);
                this.health = 5;
                this.attackType = "Soul Siphon";
                this.xpGranted = rnd.Next(3, 6);
            }
            else if (this.name == "Dusklich")
            {
                this.damage = rnd.Next(3, 6);
                this.health = 7;
                this.attackType = "Bone Requiem";
                this.xpGranted = rnd.Next(4, 9);
            }
        }

        /// <summary> Gets the monster's attack type. </summary>
        public string GetAttackType()
        {
            return this.attackType;
        }

        /// <summary> Gets the monster's damage. </summary>
        public int GetDamage()
        {
            return this.damage;
        }

        /// <summary> Gets the amount of XP the monster grants the player upon death. </summary>
        public int GetXpGranted()
        {
            return this.xpGranted;
        }
    }
}