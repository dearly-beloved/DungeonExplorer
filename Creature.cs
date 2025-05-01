using System;

/// <summary>
///
/// </summary>

namespace DungeonExplorer
{
    interface IDamageable
    {
        int GetHealth();
        void SetHealth(int healthChange);
    }

    public abstract class Creature : IDamageable
    {
        public string name;
        public int health;
        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class.
        /// </summary>
        /// <param name="name">The name of the creature.</param>
        /// <param name="health">The health of the creature.</param>
        public Creature(string name)
        {
            this.name = name;
        }

        /// <summary>Returns the Creature's name.</summary>
        /// <returns>The name string.</returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>Returns the Creature's health value.</summary>
        /// <returns>The health integer.</returns>
        public int GetHealth()
        {
            return this.health;
        }

        //// <summary>Sets the Creature's health value.</summary>
        public void SetHealth(int healthChange)
        {
            this.health += healthChange;
        }
    }
}
