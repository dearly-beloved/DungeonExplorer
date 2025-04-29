using System;

/// <summary>
/// 
/// </summary>
namespace DungeonExplorer
{
    public class Monster : Creature
    {
        private int damage;

        public Monster(string name, int health, int damage) : base(name, health)
        {
            this.damage = damage;
        }
    }
}