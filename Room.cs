using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// A class representing a Room that the Player can explore.
    /// </summary>
    public class Room
    {
        private readonly int roomId;
        private readonly string name = "";
        private readonly string description = "";
        private List<string> links = new List<string>();
        private List<string> items = new List<string>();
        private string item;
        private readonly Random rnd = new Random();
        private string noMonsters;
        private bool noItems;
        private List<string> monsters = new List<string>();

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
            if (name == "Library")
            {
                this.AddItem("Bone Key");
            }
            else
            {
                SetMonsters();
                SetItems();
            }
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

        public int GetNoItems()
        {
            return this.items.Count;
        }

        private void CountItems(List<string> items)
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

        public void AddItem(string item)
        {
            this.items.Add(item);
        }

        public void RemoveItem(string item)
        {
            this.items.Remove(item);
        }

        public string SetItems()
        {
            int itemNoRoll = rnd.Next(0, 3);
            for (int i = 0; i <= itemNoRoll; i++)
            {
                int itemRoll = rnd.Next(1, 8);
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
                        item = "Great Sword";
                        break;
                    case 5:
                        item = "Frog Leg";
                        break;
                    case 6:
                        item = "Monster Flesh";
                        break;
                    case 7:
                        item = "Ruined Book";
                        break;
                    }
                this.items.Add(item);
                Console.WriteLine(string.Join(", ", this.items));
            }
            return item;
        }

        public void SetMonsters()
        {
            string monster = "Default Monster";
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
                    monster = "Unknown Monster";
                    break;
            }
            monsters.Add(monster);
        }

        public int GetNoMonsters()
        {
            return monsters.Count;
        }

        public string GetRandomMonster()
        {
            int monsterRoll = rnd.Next(0, monsters.Count);
            string monster = monsters[monsterRoll];
            //monsters.RemoveAt(monsterRoll);
            return monster;
        }

        public string GetRandomItem()
        {
            int itemRoll = rnd.Next(0, items.Count);
            string item = items[itemRoll];
            return item;
        }
    }
}