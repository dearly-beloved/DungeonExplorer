using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonExplorer
{
    /// <summary>
    /// A class used for testing the main program.
    /// </summary>
    class TestProgram
    {
        public TestProgram()
        {
            this.TestRoomFactory();
            this.TestPlayer();
            this.TestRoom();
            this.TestCreature();
            this.TestItem();
        }
        /// <summary>
        /// Test each of the main classes and the main methods in them. Flag up errors if any of the
        /// values are not expected.
        /// </summary>
        public void TestRoomFactory()
        {
            Debug.Assert(RoomFactory.CreateRoomInstance("invalidIdentifier") == null);
            Room room = RoomFactory.CreateRoomInstance("1");
            Debug.Assert(room != null);
            Debug.Assert(room.GetName() == "Library");
            Console.WriteLine("RoomFactory test passed.");
        }

        public void TestRoom()
        {
            Room testRoom = new Room("test", "this is a test room", new List<string> {"Dagger, Apple"});
            Debug.Assert(testRoom.GetName() == "test");
            Debug.Assert(testRoom.GetDescription() == "this is a test room");
            Debug.Assert(testRoom.GetNoItems() == "2");
            Debug.Assert(testRoom.GetNoMonsters() == "0");
            Debug.Assert(testRoom.AddItem("Test Item"));
            Debug.Assert(testRoom.RemoveItem("Test Item"));
            Debug.Assert(testRoom.GetRandomMonster() == "Test");
            Debug.Assert(testRoom.GetDirection("Test"));
            Debug.Assert(testRoom.SetBoss() == "Test");
            Debug.Assert(testRoom.GetBossTrap(true) == "Test");
            Console.WriteLine("Room test passed.");
        }

        public void TestCreature()
        {
            Creature testCreature = new Creature("Test creature", 0);
            Debug.Assert(testCreature.GetName() == "Test");
            Debug.Assert(testCreature.GetHealth() == 0);
            Debug.Assert(testCreature.SetHealth(1) == 1);
            Debug.Assert(testCreature.GetAttackType() == "Test");
            Console.WriteLine("Creature test passed.");
        }

        public void TestItem()
        {
            Item testItem = new Item("Test", "Test", 0, 0);
            Debug.Assert(testItem.GetName() == "Test");
            Debug.Assert(testItem.GetTag() == "Test");
            Debug.Assert(testItem.GetAttackDamage() == 0);
            Debug.Assert(testItem.GetHpEffect() == 0);
            Console.WriteLine("Item test passed.");
        }

        public void TestPlayer()
        {
            Player testPlayer = new Player("Test", 0);
            Debug.Assert(testPlayer.GetName() == "Test");
            Debug.Assert(testPlayer.GetHealth() == 0);
            Debug.Assert(testPlayer.GetLevel() == 1);
            Debug.Assert(testPlayer.GetXp() == 0);
            Debug.Assert(testPlayer.GetLocation() == 1);
            Debug.Assert(testPlayer.AddItem("Test Item"));
            Debug.Assert(testPlayer.RemoveItem("Test Item"));
            Debug.Assert(testPlayer.GetInventoryContents() == "Test Item");
            Console.WriteLine("Player test passed.");
        }
    }
}

*/
