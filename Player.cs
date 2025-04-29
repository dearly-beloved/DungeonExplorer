using System.Collections.Generic;
using System.Linq;
using System;
///
namespace DungeonExplorer
{
    /// <summary>
    /// A class representing the Player in the text-based adventure, using a user-set name.
    /// </summary>
    public class Player : Creature
    {
        private readonly List<string> inventory = new List<string>();
        private static readonly Random rnd = new Random();
        public int level = 1;

        /// <summary>
        /// Constructs a Player object.
        /// </summary>
        /// <param name="name">The name of the Player.</param>
        /// <param name="health">The amount of health points the Player has.</param>
        public Player(string name, int health) : base(name, health)
        {
            this.name = name;
            this.health = health;
            this.inventory = new List<string>();
        }

        /// <summary>Returns the contents of the inventory list. If the inventory is empty,
        /// an empty string is returned. </summary>
        /// <returns>A string of all the elements inside of inventory, seperated by commas.</returns>
        public string GetInventoryContents()
        {
            return string.Join(", ", this.inventory);
        }

        /// <summary>Adds the parameter-specified item to the inventory list.</summary>
        /// <param name="item"> The specified item to be added to the Player's inventory.</param>
        public void PickUpItem(string item)
        {
            this.inventory.Add(item);
        }

        /// <summary>
        /// Checks if the user's inventory list contains the specified key and returns a
        /// Boolean value representing this.</summary>
        /// <returns>A Boolean value representing whether the inventory list contains the
        /// "Bone Key" item.</returns>
        public bool TryOpenDoor()
        {
            return (this.inventory.Contains("Bone Key"));
        }

        /// <summary>
        /// Checks if the inventory list is empty and, corresponding to the truth of the
        /// statement, returns a Boolean value.</summary>
        /// <returns>A Boolean value representing whether the list contains any elements.</returns>
        public bool IsInvEmpty()
        {
            return !this.inventory.Any();
        }

        public int GetLevel()
        {
            return this.level;
        }

        ///
        public void SetLevel(int level)
        {
            this.level = level;
        }

        public void UseItem(string item, int health)
        {
            if (this.inventory.Contains(item))
            {
                Console.WriteLine($"You use the {item}");
                int potRoll = rnd.Next(1, 3);
                switch (potRoll)
                {
                    case 1:
                        Console.WriteLine("Ew! BLEUGH! That potion was disgusting! You feel weird... queasy... and you lose 1 HP.");
                        health -= 1;
                        break;
                    case 2:
                        Console.WriteLine("Amazing, and... magical? You gain 1 HP, and also a nice taste in your mouth! Yum!");
                        health += 1;
                        break;
                }
            }
        }
    }
}