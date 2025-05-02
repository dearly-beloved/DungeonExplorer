using System;

namespace DungeonExplorer
{
    /// <summary>
    /// A class that initialises the game environment by instantiating a <see cref="Game"/> object,
    /// and also handles what happens when the user chooses to leave the game.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Creates a new Game object and begins the game by calling the Start method. 
        /// Handles user exit and displays corresponding messages.
        /// </summary>
        /// <param name="args">String array that stores the command-line arguments.</param>
        static void Main(string[] args)
        {
            // Testing class - remove comments for use
            //TestProgram testingInstance = new TestProgram();
            //testingInstance.TestPlayer();
            //testingInstance.TestRoom();
            //testingInstance.TestItem();
            //testingInstance.TestCreature();

            try
            {
                // Create a new game instance
                Game currentGame = new Game();

                // Create a RoomFactory instance
                RoomFactory roomFactory = new RoomFactory();

                // Start the game
                currentGame.Start(roomFactory);
            }
            finally
            {
                Console.WriteLine("\nStopped the game!");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                Console.WriteLine("See you later :D");
            }
        }
    }
}

