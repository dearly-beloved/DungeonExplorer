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
        private RoomFactory roomFactory;
        Random rnd = new Random();
        //private StateHandler stateHandler;
        /// <summary>
        /// Begins the game and all the logic and text that follows.
        /// </summary>
        public void Start(RoomFactory roomFactory)
        {
            Console.WriteLine("Welcome to the Dungeon Explorer!\n");
            Console.WriteLine("What is your name?");
            this.player = new Player(Console.ReadLine(), 20);
            Console.WriteLine($"\nHello {this.player.GetName()}!\n\nBeginning your adventure...\n");
            Thread.Sleep(1000);
            bool playing = true;
            Console.WriteLine("You finally wake up. Your head is pounding, and the suffocating air, thick with dust, " +
                "clings to your lungs. Where are you? How did you get here? \n" +
                "\n(When prompted for a choice, you may type S, I or R into the console to see info about your " +
                "Status, Inventory, or the Room you are in, and if you wish to leave the game, type exit.)\n");


            int turnNumber = 1;
            // Main game loop
            while (playing)
            {
                Thread.Sleep(2000);
                Room currentRoom = roomFactory.CreateRoomInstance("1");
                bool invalidChoice = true;
                Room previousRoom = currentRoom;
                Console.WriteLine($"You look around:\n{currentRoom.GetDescription()}");

                while (turnNumber < 50)
                {
                    Thread.Sleep(2000);
                    getOptions();
                    Console.WriteLine($"Items in the room: {string.Join(", ", currentRoom.GetItems())}");
                    string userChoice = Console.ReadLine().ToUpper();

                    // Handling the user's choices and playing the corresponding scenario
                    // Also handles erroneous user input
                    if (userChoice == "A")
                    {
                        invalidChoice = false;
                        Console.WriteLine("You decide to search the room. You look around, checking shelves and corners, listening to the weird noises that surround you.");
                        if (currentRoom.GetNoItems() > 0)
                        {
                            Thread.Sleep(2000);
                            int monsterRoll = rnd.Next(1, 6);
                            Console.WriteLine($"You rolled {monsterRoll} for the monster encounter!");
                            if (monsterRoll > 3)
                            {
                                Monster currentMonster = new Monster(currentRoom.GetRandomMonster());
                                Console.WriteLine($"You approach the glistening, trying to make out what it is... when a wretched {currentMonster.GetName()} jumps out at you!\n");
                                Console.WriteLine($"You quickly check your pockets: {this.player.GetInventoryContents()}..." +
                                    $" What do you do?\nA: Fight the {currentMonster.GetName()} with a weapon.. or your fists!\nB: Flee to safety");
                                string monsterChoice = Console.ReadLine().ToUpper();
                                invalidChoice = false;
                                if (monsterChoice == "A")
                                {
                                    Console.WriteLine("You prepare for battle.");
                                    while (currentMonster.GetHealth() > 0)
                                    {
                                        Console.WriteLine($"{currentMonster.GetName()} used {currentMonster.getAttackType()}. Press D to dodge!");
                                        string dodgeInput = Console.ReadLine().ToUpper();
                                        if (dodgeInput == "D" && player.IsInvEmpty())
                                        {
                                            Console.WriteLine($"You crouch, avoiding the attack. As the {currentMonster.GetName()} regains its strength, you deal a powerful blow, inflicting 2 damage!");
                                            Console.WriteLine($"The {currentMonster.GetName()} now has {currentMonster.GetHealth()} health left.");
                                            currentMonster.SetHealth(-2);
                                        }
                                        else if (dodgeInput == "D" && !player.IsInvEmpty())
                                        {
                                            Console.WriteLine($"You crouch, avoiding the attack. As the {currentMonster.GetName()} regains its strength, you slash at it with your sword, inflicting 6 damage!");
                                            currentMonster.SetHealth(-6);
                                        }
                                        else
                                        {
                                            Console.WriteLine($"You freeze in panic, and the {currentMonster.getAttackType()} deals {currentMonster.getDamage()} damage to you!");
                                            player.SetHealth(-(currentMonster.getDamage()));
                                            Thread.Sleep(2000);
                                            Console.WriteLine($"You now have {player.GetHealth()}/20 health.");
                                        }
                                    }
                                    Console.WriteLine($"The wretched {currentMonster.GetName()} lets out a hollow screech, falling to the ground, before crumbling into dust...");

                                    Thread.Sleep(2000);
                                    Console.WriteLine("But right where it disappeared, you see something...");
                                    Thread.Sleep(2000);
                                    string monsterDrop = currentRoom.GetRandomItem();
                                    Item item = new Item(monsterDrop);
                                    Console.WriteLine($"A {monsterDrop}! Pick it up? (Y or N)");
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
                                    Console.WriteLine("You run away in fear!");
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
                        if (this.player.TryOpenDoor())
                        {
                            currentRoom.RemoveItem("Bone Key");
                            Console.WriteLine("You put the key in the lock, and it turns! The door creaks as you push it open...");
                            Thread.Sleep(1000);
                            Console.WriteLine("You look around...");
                            string links = roomFactory.GetConnectedRooms(0);
                            currentRoom.ChooseNextRoom();
                            Console.WriteLine(links);
                            Console.WriteLine("You see the following rooms: " + links);
                            previousRoom = currentRoom;
                            Room newRoom = roomFactory.CreateRoomInstance("3"); //make a method for deciding next connecting room ya know 
                            currentRoom = newRoom;
                            Console.WriteLine($"You are now in the {currentRoom.GetName()}.");
                        }
                        else
                        {
                            Console.WriteLine("You try to turn the handle, but it doesn't budge. You should try to find a key...");
                        }
                    }

                    else if (userChoice == "C")
                    {
                        if (previousRoom == currentRoom)
                        {
                            Console.WriteLine("You haven't explored another room yet!");
                        }
                        else
                        {
                            invalidChoice = false;
                            Console.WriteLine($"You decide to go back to the {previousRoom.GetName()}.");
                            previousRoom = currentRoom;
                            Room newRoom = roomFactory.CreateRoomInstance("1");
                            currentRoom = newRoom;
                            Console.WriteLine($"You are now in the {currentRoom.GetName()}.");
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
                            Console.WriteLine("Would you like to use or remove an item? ('Use', 'Remove', or 'No'):");
                            string invChoice = Console.ReadLine().ToUpper();
                            if (invChoice == "USE")
                            {
                                Console.WriteLine("Which item would you like to use?");
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
                        int hp = this.player.GetHealth();
                        Console.WriteLine($"You currently have {hp} health and you are in the {currentRoom.GetName()}!");
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
            }
        }
        public void getOptions()
        {
            Console.WriteLine("What do you do?\n");
            Console.WriteLine("A: Search the room");
            Console.WriteLine("B: Try to open the door");
            Console.WriteLine("C: Go to previous room");
            Console.WriteLine("I: Manage your inventory");
            Console.WriteLine("R: Look around the room");
            Console.WriteLine("S: Check your status");
            Console.WriteLine("EXIT: Leave the game\n");
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
            if (item == "Bone Key")
            {
                itemRoll = 1;
            }
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
        }
    }
}




