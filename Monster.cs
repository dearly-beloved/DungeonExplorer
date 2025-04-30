using System;

/// <summary>
/// 
/// </summary>
namespace DungeonExplorer
{
    public class Monster : Creature
    {
        protected int damage;
        private readonly Random rnd = new Random();
        protected string attackType;

        public Monster(string name) : base(name)
        {
            if (this.name == "Rotling")
            {
                this.damage = rnd.Next(1, 5);
                this.health = 4;
                this.attackType = "Blood Frenzy";
            }
            else if (this.name == "Cryptseer Mage")
            {
                this.damage = rnd.Next(2, 6);
                this.health = 5;
                this.attackType = "Soul Siphon";
            }
            else if (this.name == "Dusklich")
            {
                this.damage = rnd.Next(3, 6);
                this.health = 7;
                this.attackType = "Bone Requiem";
            }
        }

        public string getAttackType()
        {
            return this.attackType;
        }
        
        public int getDamage()
        {
            return this.damage;
        }

    }

    public class Boss : Monster
    {
        public Boss(string name) : base(name)
        {
            if (name == "Death Knight") //Prison cell boss
                {
                this.damage = 6;
                this.health = 20;
                this.attackType = "Soul Reaver";
            }
            else if (name == "Lich King") //Garden boss
            {
                this.damage = 7;
                this.health = 25;
                this.attackType = "Wail of the Damned";
            }
        }
    }
}