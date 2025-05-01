using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Threading;

namespace DungeonExplorer
{
    /// <summary>
    /// A class representing the main Game logic and responsible for creating instances of the 
    /// <see cref="Room"/> and <see cref="RoomFactory"/> classes.
    /// </summary>

    internal class Game
    {
        private Player player;
        Random rnd = new Random();
        /// <summary>
        /// Begins the game and all the logic and text that follows.
        /// </summary>
        public void Start(RoomFactory roomFactory)
        {
            Console.WriteLine("Welcome to the Dungeon Explorer!\n");
            Console.WriteLine("What is your name?");
            Console.Write("> ");
            this.player = new Player(Console.ReadLine(), 15);
            Console.WriteLine($"\nHello {this.player.GetName()}!\n\nBeginning your adventure...\n");
            Thread.Sleep(1000);
            Console.WriteLine("You finally wake up. Your head is pounding, and the suffocating air, thick with dust, " +
                "clings to your lungs. Where are you? How did you get here? \n");
            Room currentRoom = roomFactory.CreateRoomInstance("1");
            bool invalidChoice = false;

            // Main game loop
            while (player.GetHealth() > 0)
            {
                Thread.Sleep(2000);
                Room previousRoom = currentRoom;
                Console.WriteLine($"You look around:\n{currentRoom.GetDescription()}");
                Thread.Sleep(2000);
                GetOptions();
                //Console.WriteLine($"Items in the room: {string.Join(", ", currentRoom.GetItems())}"); //temp
                Console.Write("> ");
                string userChoice = Console.ReadLine().ToUpper();

                // Handling the user's choices and playing the corresponding scenario
                // Also handles erroneous user input
                if (userChoice == "A")
                {
                    invalidChoice = false;
                    Console.WriteLine("\nYou decide to search the room. You look around, checking shelves and corners, listening to the weird noises that surround you.");
                    if (currentRoom.GetNoItems() > 0)
                    {
                        Thread.Sleep(2000);
                        int monsterRoll = rnd.Next(1, 6);
                        //Console.WriteLine($"You rolled {monsterRoll} for the monster encounter!");
                        if (monsterRoll > 2)
                        {
                            Monster currentMonster = new Monster(currentRoom.GetRandomMonster());
                            Console.WriteLine($"You approach the glistening, trying to make out what it is... when a wretched {currentMonster.GetName()} jumps out at you!\n");
                            Console.WriteLine($"You quickly check your pockets: {this.player.GetInventoryContents()}..." +
                                $" What do you do?\nA: Fight the {currentMonster.GetName()} with a weapon... or your fists!\nB: Flee to safety\n");
                            Console.Write("> ");
                            string monsterChoice = Console.ReadLine().ToUpper();
                            invalidChoice = false;
                            if (monsterChoice == "A")
                            {
                                Console.WriteLine("You prepare for battle.\n");
                                while (currentMonster.GetHealth() > 0)
                                {
                                    Console.WriteLine($"{currentMonster.GetName()} used {currentMonster.GetAttackType()}!");
                                    Console.WriteLine("Press D to dodge!\n");
                                    Console.Write("> ");
                                    string dodgeInput = Console.ReadLine().ToUpper();
                                    if (dodgeInput == "D" && player.IsInvEmpty())
                                    {
                                        Console.WriteLine($"You crouch, avoiding the attack. As the {currentMonster.GetName()} regains its strength, you deal a powerful blow, inflicting 2 damage!\n");
                                        Console.WriteLine($"The {currentMonster.GetName()} now has {currentMonster.GetHealth()} health left.\n");
                                        currentMonster.SetHealth(-2);
                                    }
                                    else if (dodgeInput == "D" && !player.IsInvEmpty())
                                    {
                                        Console.WriteLine($"You crouch, avoiding the attack. As the {currentMonster.GetName()} regains its strength, you slash at it with your sword, inflicting 6 damage!\n");
                                        currentMonster.SetHealth(-6);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"You freeze in panic, and the {currentMonster.GetAttackType()} deals {currentMonster.GetDamage()} damage to you!\n");
                                        player.SetHealth(-(currentMonster.GetDamage()));
                                        Thread.Sleep(2000);
                                        Console.WriteLine($"You now have {player.GetHealth()}/20 health.\n");
                                    }
                                }
                                Console.WriteLine($"The wretched {currentMonster.GetName()} lets out a hollow screech, falling to the ground, before crumbling into dust...\n");
                                Console.WriteLine($"You gained {currentMonster.GetXpGranted()} XP!\n");
                                player.SetXp(currentMonster.GetXpGranted());
                                Thread.Sleep(2000);
                                Console.WriteLine("But right where it disappeared, you see something...\n");
                                Thread.Sleep(2000);
                                string monsterDrop = currentRoom.GetRandomItem();
                                Item currentItem = new Item(monsterDrop);
                                Console.WriteLine($"A {monsterDrop}! Pick it up? (Y or N)\n");
                                Console.Write("> ");
                                string itemChoice = Console.ReadLine().ToUpper();
                                if (itemChoice == "Y")
                                {
                                    this.player.PickUpItem(monsterDrop);
                                    Thread.Sleep(1000);
                                    Console.WriteLine($"You carefully put the {monsterDrop} in your backpack.\n");
                                    currentRoom.RemoveItem(monsterDrop);
                                }
                                else if (itemChoice == "N")
                                {
                                    Console.WriteLine($"You leave the {monsterDrop} behind, and walk away.");
                                }
                            }
                            else if (monsterChoice == "B")
                            {
                                Console.WriteLine("You run away in fear!\n");
                            }
                            else
                            {
                                invalidChoice = true;
                                Console.WriteLine($"You entered an invalid option. You freeze, panicked, as the {currentMonster.GetName()} leaps at you. As you run away, it scratches your arm, inflicting 1 damage.");
                                player.SetHealth(-1);
                            }

                        }
                        else
                        {
                            string item = currentRoom.GetRandomItem();
                            ItemEncounter(item);
                            currentRoom.RemoveItem(item);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no more items left in this room...");
                    }
                }

                else if (userChoice == "B")
                {
                    invalidChoice = false;
                    Console.WriteLine("Which way would you like to go? (Enter a direction - N, E, S or W)");
                    Console.Write("> ");
                    string direction = Console.ReadLine().ToUpper();
                    if (direction != "N" && direction != "E" && direction != "S" && direction != "W")
                    {
                        Console.WriteLine("You didn't enter a valid direction!");
                    }
                    int checkDirection = currentRoom.GetDirection(direction);
                    if (checkDirection == -1)
                    {
                        Console.WriteLine("You can't go that way from here.\n");
                    }
                    else
                    {
                        if (this.player.TryOpenDoor())
                        {
                            Room newRoom = roomFactory.CreateRoomInstance(checkDirection.ToString());
                            currentRoom.RemoveItem("Bone Key");
                            currentRoom = newRoom;
                            Console.WriteLine("You put the key in the lock, and it turns! The door creaks as you push it open...");
                            Thread.Sleep(1000);
                            Console.WriteLine($"You are now in the {currentRoom.GetName()}.\n");
                        }
                        else
                        {
                            Console.WriteLine("You try to turn the handle, but it doesn't budge. You should try to find a key...");
                        }

                        if (currentRoom.GetName() == "Prison Cell")
                        {
                            currentRoom.GetBossTrap(player.CheckIfInInv("Rusted Helm"));
                        }
                        else if (currentRoom.GetName() == "Garden")
                        {
                            currentRoom.GetBossTrap(player.CheckIfInInv("Withered Rose"));
                        }
                        currentRoom.SetBoss();
                    }
                }

                else if (userChoice == "C")
                {
                    if (previousRoom == currentRoom)
                    {
                        Console.WriteLine("You haven't explored another room yet!\n");
                    }
                    else
                    {
                        invalidChoice = false;
                        Console.WriteLine($"You decide to go back to the {previousRoom.GetName()}.");
                        currentRoom = previousRoom;
                        Console.WriteLine($"You are now in the {currentRoom.GetName()}.\n");
                    }
                }

                else if (userChoice == "I")
                {
                    invalidChoice = false;
                    Console.WriteLine("You open your backpack...");
                    if (this.player.IsInvEmpty())
                    {
                        Console.WriteLine("Your inventory contains... cobwebs. It's empty.\n");
                    }
                    else
                    {
                        Console.WriteLine("Your inventory contains: " + this.player.GetInventoryContents());
                        Console.WriteLine("Would you like to use or remove an item, or perhaps filter your inventory? ('Use', 'Remove', 'Filter' or 'No')");
                        Console.Write("> ");
                        string invChoice = Console.ReadLine().ToUpper();
                        if (invChoice == "USE")
                        {
                            Console.WriteLine("Which item would you like to use?");
                            Console.Write("> ");
                            string itemChoice = Console.ReadLine().ToUpper();
                            if (player.CheckIfInInv(itemChoice.ToLower()))
                            {
                                player.UseItem(itemChoice);
                                player.RemoveItem(itemChoice);
                            }
                            else
                            {
                                Console.WriteLine("That item isn't in your inventory!");
                            }
                        }
                        else if (invChoice == "REMOVE")
                        {
                            Console.WriteLine("Which item would you like to remove?");
                            Console.Write("> ");
                            string itemChoice = Console.ReadLine().ToUpper();
                            if (player.CheckIfInInv(itemChoice.ToLower()))
                            {
                                player.RemoveItem(itemChoice);
                                Console.WriteLine($"You toss the {itemChoice} away.");
                                Console.WriteLine("Your inventory now contains: " + this.player.GetInventoryContents());
                            }
                            else
                            {
                                Console.WriteLine("That item isn't in your inventory!");
                            }
                        }
                        else if (invChoice == "FILTER")
                        {
                            Console.WriteLine("How would you like to filter your inventory? (By type: W for weapons, P for potions, O for other");
                            Console.Write("> ");
                            string sortChoice = Console.ReadLine().ToUpper();
                            if (sortChoice == "W" || sortChoice == "P" || sortChoice == "O")
                            {
                                Console.Write("Your inventory contains these items of the specified type:");
                                player.FilterInventory(sortChoice);
                            }
                            else
                            {
                                Console.WriteLine("Please enter a valid option!");
                            }
                        }
                        else if (invChoice == "NO")
                        {
                            Console.WriteLine("You close your backpack.");
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid option!");
                        }
                    }
                }

                else if (userChoice == "R")
                {
                    invalidChoice = false;
                    Console.WriteLine(currentRoom.GetDescription());
                    Console.WriteLine($"There are {currentRoom.GetNoItems()} items left in the room...");
                }

                else if (userChoice == "S")
                {
                    invalidChoice = false;
                    Console.WriteLine($"You currently have {player.GetHealth()} health, are level {player.GetLevel()} and you are in the {currentRoom.GetName()}!");
                }

                else if (userChoice == "EXIT")
                {
                    invalidChoice = false;
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter a valid option!");
                }
            }

            Console.WriteLine("Your strength fades, the cold takes hold, and darkness swallows everything...");
            Thread.Sleep(3000);
            Console.WriteLine("You died! :(");
            return;
        }

        /// <summary> Displays the options available to the player. </summary>
        public void GetOptions()
        {
            Console.WriteLine("\nWhat do you do?\n" +
                "A: Search the room\n" +
                "B: Try to go to the next room\n" +
                "C: Go to previous room\n" +
                "I: Manage your inventory\n" +
                "R: Look around the room\n" +
                "S: Check your status\n" +
                "EXIT: Leave the game\n");
        }

        /// <summary> Handles the encounter with an item in the room. </summary>
        /// <param name="item">The item that was encountered.</param>
        public void ItemEncounter(string item)
        {
            Console.WriteLine($"\nThe glistening turned out to be a {item}! You try to grab it...\n");
            if (player.GetInventorySize() < 10)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Rolling dice... Roll a number that is smaller than 8 to pick up the item!\n");
                Thread.Sleep(1000);
                Console.WriteLine("You rolled...\n");
                Thread.Sleep(1000);
                int itemRoll = rnd.Next(1, 10);
                if (item == "Bone Key")
                {
                    itemRoll = 1;
                }
                Console.WriteLine(itemRoll + "!\n");
                if (itemRoll < 8)
                {
                    this.player.PickUpItem(item);
                    Thread.Sleep(1000);
                    Console.WriteLine($"You carefully put the {item} in your backpack.\n");
                }
                else
                {
                    Console.WriteLine($"Oops! A huge spider crawls out from behind the {item}, startling you. " +
                        "You drop it onto the floor, and it disappears into thin air.\n");
                }

                if (!this.player.IsInvEmpty())
                {
                    Console.WriteLine($"Your inventory contents are now: {this.player.GetInventoryContents()}\n");
                }
            }
            else
            {
                Console.WriteLine("You check your backpack... but you don't any space for anything else.");
            }
        }
    }
}




