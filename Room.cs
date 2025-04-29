using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// A class representing a Room that the Player can explore.
    /// </summary>
    public class Room
    {
        private readonly string name = "";
        private readonly string description = "";
        private List<string> items = new List<string>();
        private List<string> links = new List<string>();
        private string item;
        private readonly Random rnd = new Random();
        private string monster;

        //private readonly string name = "";

        /// <summary>
        /// Constructs a Room object.
        /// </summary>
        /// <param name="name">The name of the Room.</param>
        /// <param name="description">The description of the Room.</param>
        /// <param name="items">The items that are inside of the Room.</param>
        public Room(string name, string description, string links)
        {
            if (name != null)
            {
                this.name = name;
            }
            if (description != null)
            {
                this.description = description;
            }
            this.SetItems(items);
        }

        /// <summary>Returns the Room's name.</summary>
        /// <returns>The name string.</returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>Returns the Room's description.</summary>
        /// <returns>The description string.</returns>
        public string GetDescription()
        {
            return this.description;
        }

        private void SetItems(List<string> items)
        {
            if (items != null && items.Count > 0)
            {
                items.ForEach(item =>
                {
                    this.AddItem(item);
                });
            }
            else
            {
                this.items = new List<string>();
            }
        }

        private void AddItem(string item)
        {
            this.items.Add(item);
        }

        public string GetRandomItem()
        {
            int itemRoll = rnd.Next(1, 4);
            switch (itemRoll)
            {
                case 1:
                    item = "Dagger";
                    break;
                case 2:
                    item = "Spell Book";
                    break;
                case 3:
                    item = "Mysterious Potion";
                    break;
                case 4:
                    item = "No item";
                    break;
            }
            return item;
        }

        public string SpawnMonster()
        {
            int monsterRoll = rnd.Next(1, 4);
            switch (monsterRoll)
            {
                case 1:
                    monster = "Dusklich";
                    break;
                case 2:
                    monster = "Rotling";
                    break;
                case 3:
                    monster = "Cryptseer Mage";
                    break;
                default:
                    monster = "Unknown Monster"; // Fallback case
                    break;
            }
            return monster;

        }
    }
}