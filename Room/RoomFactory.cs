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
            { "1", "Library", "A dusty library full of sorcery tomes and alchemy books. The air feels tense and you feel strange. You see something glistening at the top of a shelf... and is that a door at the east end of the room?", "-1", "3", "-1", "-1", "Bone Key"},
            { "2", "Cellar",  "A dark and damp cellar. You can hear the sound of dripping water echoing in the distance. You can almost make out a door at the end of the room.", "-1", "7", "-1", "3"},
            { "3", "Hallway", "The hallway stretches ahead, its floorboards creaking, and is lit up by unnatural lights. You see doors on each side of the hall.", "5", "2", "4", "1"},
            { "4", "Kitchen", "The kitchen is dim, with worn cabinets, a rusty stove, and a faint, unsettling odor of decayed flesh. Through the smashed windows, you can see a garden to the South.", "3", "-1", "6", "-1"},
            { "5", "Bedroom", "A dark and quiet bedroom with a worn bedspread and dusty furniture.", "-1", "-1", "3", "-1"},
            { "6", "Garden",  "A wilted garden, once vibrant, now overrun with dry, brittle plants and the scent of decay in the air.", "4", "-1", "-1", "-1", "Withered Rose"},
            { "7", "Prison Cell", "A small, damp prison cell with cold stone walls and a rusted bed frame. You can almost hear... breathing?", "-1", "-1", "-1", "2", "Rusty Helm"}
        };

        /// <summary> Method that creates a new instance of the <see cref="Room"/> class. </summary>
        public Room CreateRoomInstance(string CurrentRoomId)
        {
            for (int i = 0; i < roomData.GetLength(0); i++)
            {
                if (roomData[i, 0] == CurrentRoomId)
                {
                    return new Room(
                        roomData[i, 1],
                        roomData[i, 2],
                        int.Parse(roomData[i, 3]),
                        int.Parse(roomData[i, 4]),
                        int.Parse(roomData[i, 5]),
                        int.Parse(roomData[i, 6])
                    );
                }
            }
            return null;
        }
    }
}