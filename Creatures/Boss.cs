using System;

namespace DungeonExplorer
{
    /// <summary> A class representing a boss monster in the text-based adventure. </summary>
    /// <remarks> The Boss class inherits from the Monster class. </remarks>
    public class Boss : Monster, IFightable, IDamageable
    {
        private bool status;

        public Boss(string name) : base(name)
        {
            if (name == "Death Knight") //Prison cell boss
            {
                this.damage = 6;
                this.health = 20;
                this.attackType = "Soul Reaver";
                this.xpGranted = 15;
                this.status = true;
            }
            else if (name == "Lich King") //Garden boss
            {
                this.damage = 7;
                this.health = 25;
                this.attackType = "Wail of the Damned";
                this.xpGranted = 20;
                this.status = true;
            }
        }

        public void SetStatus()
        {
            this.status = false;
        }

        public bool GetStatus()
        {
            return this.status;
        }
    }
}