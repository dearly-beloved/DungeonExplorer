/*
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
            RoomFactory roomFactory = new RoomFactory();
            Debug.Assert(roomFactory.CreateRoomInstance("invalidIdentifier") == null);
            Room room = roomFactory.CreateRoomInstance("1");
            Debug.Assert(room != null);
            Debug.Assert(room.GetName() == "Library");
            Console.WriteLine("RoomFactory test passed.");
        }

        public void TestRoom()
        {
            Room testRoom = new Room("test", "this is a test room", -1, -1, -1, -1);
            Debug.Assert(testRoom.GetName() == "test");
            Debug.Assert(testRoom.GetDescription() == "this is a test room");
            Debug.Assert(testRoom.GetNoItems() == 0);
            Debug.Assert(testRoom.GetNoMonsters() == 0);
            testRoom.AddItem("Test Item");
            testRoom.RemoveItem("Test Item");
            Debug.Assert(testRoom.GetRandomMonster() == "Test");
            Debug.Assert(testRoom.GetDirection("1") != 0);
            testRoom.SetBoss();
            testRoom.GetBossTrap(true);
            Console.WriteLine("Room test passed.");
        }

        public void TestCreature()
        {
            Creature testCreature = new Monster("Test creature");
            Debug.Assert(testCreature.GetName() == "Test creature");
            Debug.Assert(testCreature.GetHealth() == 0);
            testCreature.SetHealth(1);
            Debug.Assert(testCreature.GetHealth() == 1);
            Console.WriteLine("Creature test passed.");
        }

        public void TestItem()
        {
            Item testItem = new Item("Test");
            Debug.Assert(testItem.GetName() == "Test");
            Debug.Assert(testItem.GetTag() == "Test");
            Console.WriteLine("Item test passed.");
        }

        public void TestPlayer()
        {
            Player testPlayer = new Player("Test", 0);
            Debug.Assert(testPlayer.GetName() == "Test");
            Debug.Assert(testPlayer.GetHealth() == 0);
            Debug.Assert(testPlayer.GetLevel() == 1);
            testPlayer.PickUpItem("Test Item");
            Debug.Assert(testPlayer.CheckIfInInv("Test Item"));
            testPlayer.RemoveItem("Test Item");
            Debug.Assert(!testPlayer.CheckIfInInv("Test Item"));
            Console.WriteLine("Player test passed.");
        }
    }
}

*/

