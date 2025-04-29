using System.Collections.Generic;
using System.Security.Cryptography;

namespace DungeonExplorer
{
    /// <summary>
    /// A factory class responsible for creating instances of <see cref="Room"/> based on a room identifier.
    /// </summary>
    public class RoomFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="Room"/> based on a passed room identifier.
        /// </summary>
        /// <param name="roomIdentifier"> The identifier to create a <see cref="Room"/> instance from.</param>
        /// <returns>The corresponding instance of <see cref="Room"/>, or null if no room identifier can be matched.</returns>
        /// 

        string[,] roomData = {
            { "1", "Library", "A dusty library full of sorcery tomes and alchemy books. The air feels tense and you feel strange. You see something glistening at the top of a shelf... and is that a door at the east end of the room?", "East:Hallway"},
            { "2", "Cellar",  "A dark and damp cellar. You can hear the sound of dripping water echoing in the distance." , "West:Hallway, East:Prison Cell"},
            { "3", "Hallway", "A long and narrow hallway.", "West:Library, East:Cellar, South:Kitchen, North:Bedroom" },
            { "4", "Kitchen", "A large kitchen with a long table in the center.", "North:Hallway, South:Garden"},
            { "5", "Bedroom", "A small bedroom with a bed and a wardrobe.", "South:Hallway"},
            { "6", "Garden",  "A wilted garden full of dead trees and flowers.", "North:Kitchen"},
            { "7", "Prison Cell", "A dark and damp prison cell.", "West:Cellar"}
            };

        public Room CreateRoomInstance(string CurrentRoomId)
        {
            for (int i = 0; i < roomData.GetLength(0); i++)
            {
                if (roomData[i, 0] == CurrentRoomId)
                {
                    return new Room(roomData[i, 1], roomData[i, 2], roomData[i, 3]);
                }
                return null;
            }
        }

        public string GetConnectedRooms(int CurrentRoomId)
            {
            return roomData[CurrentRoomId, 3];
            }
        }
    }
}