using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;

namespace DungeonExplorer
{

    interface IPlayable
    {
        void GetInventoryContents();
    }

    /// <summary>
    /// A class representing the Player in the text-based adventure, using a user-set name.
    /// </summary>
    public class Player : Creature, IPlayable
    {
        private readonly List<string> inventory = new List<string>();
        private static readonly Random rnd = new Random();
        public int level = 1;
        public int xp = 0;
        public int location = 1;

        /// <summary>
        /// Constructs a Player object.
        /// </summary>
        /// <param name="name">The name of the Player.</param>
        /// <param name="health">The amount of health points the Player has.</param>
        public Player(string name, int health) : base(name)
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

        public int GetInventorySize()
        {
            return this.inventory.Count;
        }

        /// <summary>Returns the Player's health value.</summary>
        /// <returns>The level integer.</returns>
        public int GetLevel()
        {
            return this.level;
        }

        /// <summary>Handles the leveling up of the Player. If the Player's XP exceeds the amount
        /// required to level up, the Player's level increases by 1 and their XP is reset to 0.</summary>
        /// <param name="xp">The amount of XP to be added to the Player's current XP.</param>
        public void SetXp(int xp)
        {
            int levelXp = (level * 5) + 1; // Amount of xp required to get to next level, scaling with the player's level
            this.xp += xp;
            if (this.xp > levelXp)
            {
                this.level += 1;
                this.xp = 0;
                Console.WriteLine($"You leveled up to level {this.level}!");
            }
        }

        /// <summary>Adds the parameter-specified item to the inventory list.</summary>
        /// <param name="item"> The specified item to be added to the Player's inventory.</param>
        public void PickUpItem(string item)
        {
            this.inventory.Add(item);
        }

        /// <summary>Checks if the inventory list contains the specified item.</summary>
        /// <param name="item">The specified item to be checked for in the Player's inventory.</param>

        public bool CheckIfInInv(string item)
        {
            return inventory.Contains(item, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>Removes the specified item from the inventory list. If the item is not in the
        /// inventory, an error message is printed to the console.</summary>
        /// <param name="item">The specified item to be removed from the Player's inventory.</param>
        public void RemoveItem(string item)
        {
            if (inventory.Contains(item, StringComparer.OrdinalIgnoreCase))
            {
                inventory.RemoveAt(inventory.FindIndex(n => n.Equals(item, StringComparison.OrdinalIgnoreCase)));
            }
            else
            {
                Console.WriteLine("This item doesn't exist!");
            }
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

        /// <summary> Uses the item specified by the parameter. If the item is in the inventory, it
        /// goes through a specific scenario of effects depending on the item. </summary>
        /// <param name="item">The item to be used.</param>
        public void UseItem(string item)
        {
            if (this.inventory.Contains(item, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine($"You consume the {item}...");
                if (item == "Mysterious potion")
                {
                    int potRoll = rnd.Next(1, 3);
                    switch (potRoll)
                    {
                        case 1:
                            Console.WriteLine("Ew! BLEUGH! That potion was disgusting! You feel weird... queasy... and you lose 1 HP.");
                            this.health -= 1;
                            break;
                        case 2:
                            Console.WriteLine("Amazing, and... magical? You gain 4 HP, and also a nice taste in your mouth! Yum!");
                            this.health += 1;
                            break;
                    }
                }
                else if (item == "Spell book")
                {
                    Console.WriteLine("You open the spell book and read a few pages. You feel more powerful!");
                    this.SetXp(5);
                }
                else if (item == "Frog leg")
                {
                    int frogRoll = rnd.Next(1, 5);
                    if (frogRoll > 3)
                    {
                        Console.WriteLine("You eat the frog leg. It tastes like... chicken!? You gain 2 HP!");
                        this.health += 2;
                    }
                    else
                    {
                        Console.WriteLine("You eat the frog leg. It tastes like... frog. You lose 2 HP. Ew.");
                        this.health -= 2;
                    }
                }
                else
                {
                    Console.WriteLine("You can't use this item right now.");
                }
            }
            else
            {
                Console.WriteLine("No item of that name is in your inventory!");
            }
        }

        /// <summary> Filters the inventory list based on the specified item tag. </summary>
        /// <param name="itemTag">The tag to filter the inventory by.</param>
        public void FilterInventory(string itemTag)
        {
            var filterChoice = from i in this.inventory
                               where i.IndexOf(itemTag, StringComparison.OrdinalIgnoreCase) >= 0
                               select i;

            foreach (var item in filterChoice)
            {
                Console.WriteLine(item);
            }
        }
    }
}