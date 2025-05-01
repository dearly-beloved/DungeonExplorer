using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace DungeonExplorer
{
    /// <summary>
    /// A class representing a Room that the Player can explore.
    /// </summary>
    public class Room
    {
        private readonly Random rnd = new Random();
        private readonly string name = "";
        private readonly string description = "";
        private List<string> items = new List<string>();
        private string item;
        private List<string> monsters = new List<string>();

        private int North;
        private int East;
        private int South;
        private int West;

        /// <summary>
        /// Constructs a Room object.
        /// </summary>
        /// <param name="name">The name of the Room.</param>
        /// <param name="description">The description of the Room.</param>>
        /// <param name="North">etc. The ID of the rooms that are connected to the current room.</param>
        public Room(string name, string description, int North, int East, int South, int West)
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
            else if (name == "Prison Cell")
            {
                this.AddItem("Rusty Helm");
            }
            else if (name == "Garden")
            {
                this.AddItem("Withered Rose");
            }
            
            this.SetMonsters();
            this.SetItems();
            
            this.North = North;
            this.East = East;
            this.South = South;
            this.West = West;
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

        /// <summary>Returns the number of items in the Room.</summary>
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

        /// <summary>Adds an item to the items in the room.</summary>
        /// <param name="item">The item to be added.</param>
        public void AddItem(string item)
        {
            this.items.Add(item);
        }

        /// <summary>Removes the item from the room.</summary>
        /// <param name="item">The item to be removed.</param>
        public void RemoveItem(string item)
        {
            this.items.Remove(item);
        }

        /// <summary>Sets a random number of random items to be inside of the room.</summary>
        /// <returns>The item that was added.</returns>
        public string SetItems()
        {
            int itemNoRoll = rnd.Next(0, 3);
            for (int i = 0; i <= itemNoRoll; i++)
            {
                int itemRoll = rnd.Next(1, 8);
                switch (itemRoll)
                {
                    case 1:
                        this.items.Add("Dagger");
                        break;
                    case 2:
                        this.items.Add("Spell Book");
                        break;
                    case 3:
                        this.items.Add("Mysterious Potion");
                        break;
                    case 4:
                        this.items.Add("Great Sword");
                        break;
                    case 5:
                        this.items.Add("Frog Leg");
                        break;
                    case 6:
                        this.items.Add("Monster Flesh");
                        break;
                    case 7:
                        this.items.Add("Ruined Book");
                        break;
                }
            }
            return item;
        }

        /// <summary>Returns the items in the room.</summary>
        public string GetItems()
        {
            return string.Join(", ", this.items);
        }

        /// <summary>Sets the monsters to be in the room.</summary>
        public void SetMonsters()
        {
            string monster = "Default Monster";
            int noMonsters = rnd.Next(1, 3);
            for (int i = 0; i < noMonsters; i++)
            {
                int monsterRoll = rnd.Next(1, 4);
                switch (monsterRoll)
                {
                    case 1:
                        monsters.Add("Dusklich");
                        break;
                    case 2:
                        monsters.Add("Rotling");
                        break;
                    case 3:
                        monsters.Add("Cryptseer Mage");
                        break;
                }
            }

        /// <summary>Returns the number of monsters in the room.</summary>
        public int GetNoMonsters()
        {
            return monsters.Count;
        }

        /// <summary>Returns a random monster from the room.</summary>
        /// <returns>The monster that was removed from the room.</returns>
        public string GetRandomMonster()
        {
            if (monsters.Count == 0)
            {
                throw new InvalidOperationException("No monsters left in the room.");
            }
            int monsterRoll = rnd.Next(0, monsters.Count);
            string monster = monsters[monsterRoll];
            monsters.RemoveAt(monsterRoll);
            return monster;

        }

        /// <summary>Returns a random item from the room.</summary>
        /// <return>s>The item that was removed from the room.</returns>
        public string GetRandomItem()
        {
            int itemRoll = rnd.Next(0, items.Count);
            string item = items[itemRoll];
            return item;
        }

        /// <summary>Returns the ID of corresponding rooms that are linked to the current room.</summary>
        /// <param name="direction">The direction to check for a room.</param>
        /// <returns>The ID of the room in the specified direction.</returns>
        public int GetDirection(string direction)
        {
            if (direction == "N")
            {
                return this.North;
            }
            else if (direction == "E")
            {
                return this.East;
            }
            else if (direction == "S")
            {
                return this.South;
            }
            else if (direction == "W")
            {
                return this.West;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>Handles a boss room scenario when a player picks up a trap item.</summary>
        /// <param name="TrapItemPicked">Indicates if the trap item was picked up.</param>
        public void GetBossTrap(bool TrapItemPicked)
        {
            if (this.name == "Prison Cell" && TrapItemPicked)
                {
                Console.WriteLine("You pick up the rusty helmet off the floor, brushing the dust off it...");
                Thread.Sleep(1000);
                Console.WriteLine("When all of a sudden, you hear a deep sigh.");
                Thread.Sleep(1000);
                Console.WriteLine("The first breath of the death knight echoes through the room, cold and suffocating, like the exhale of the grave itself, carrying the weight of centuries of death.");
            }
            else if (this.name == "Garden" && TrapItemPicked)
                {
                Console.WriteLine("You feel a strange allure towards a certain withered rose. Holding it gently with your fingers, you pluck it from its weak stem.");
                Thread.Sleep(1000);
                Console.WriteLine("The Lich King steps from the void, his chilling presence cracking the air and splitting the earth as death answers his call.");
            }
        }

        /// <summarySets the boss in the room.</summary>
        public void SetBoss()
        {
            if (this.name == "Prison Cell")
            {
                monsters.Add("Death Knight");
            }
            else if (this.name == "Garden")
            {
                monsters.Add("Lich King");
            }
        }
    }
}