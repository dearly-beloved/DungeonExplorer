using System;

/// <summary>
/// 
/// </summary>
namespace DungeonExplorer
{
    public class Monster : Creature
    {
        private string name;
        private int damage;

        public Monster(string name, int health, int damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
        }
    }
}