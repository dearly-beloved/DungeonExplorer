using System;

namespace DungeonExplorer
{
    public void class GameStateHandler
    {
        public void UpdateOptions()
        {
            Console.WriteLine("A: Search the room\nB: Go back to previous room\nC: Fight monster");
        }
    }

        public void MonsterEncounter(string monster)
        {
            Console.WriteLine($"You approach the glistening...\n A wretched {monster} jumps out at you!\n");
            Console.WriteLine("What do you do?")
        }

    }
        public void ItemEncounter(string item)
        {
            Console.WriteLine($"\nThe glistening turned out to be a {item}! You try to grab it off the shelf...\n");
            Thread.Sleep(1000);
            Console.WriteLine("Rolling dice... Roll a number that is smaller than 8 to pick up the item!\n");
            Thread.Sleep(1000);
            Console.WriteLine("You rolled...\n");
            Thread.Sleep(1000);
            int itemRoll = rnd.Next(1, 10);
            Console.WriteLine(itemRoll + "!");
            if (itemRoll < 8)
            {
                this.player.PickUpItem(item);
                Thread.Sleep(1000);
                Console.WriteLine($"You carefully put the {item} in your backpack.\n");
            }
            else
            {
                Console.WriteLine($"Oops! A huge spider crawls out from behind the {item}, startling you. " +
                    "You drop it onto the floor, and it gets stuck under a bookshelf.\n");
            }
            if (!this.player.IsInvEmpty())
            {
                Console.WriteLine($"Your inventory contents are now: {this.player.GetInventoryContents()}\n");
            }
            else
            {
                Console.WriteLine("Your inventory is still empty.\n");
            }
        }

        public 

        
