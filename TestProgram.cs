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
        }

        public void TestRoom()
        {
            //Room testRoom = new Room("test", "this is a test room", new List<string> {"Dagger, Apple"});
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
        }

        public void TestCreature()
        {
            //Creature testCreature = new Creature("test", 0);
            Debug.Assert(testCreature.GetName() == "test");
            Debug.Assert(testCreature.GetHealth() == 0);
            Debug.Assert(testCreature.SetHealth(1) == 1);
            Debug.Assert(testCreature.GetAttackType() == "Test");
        }

        public void TestItem()
        {
            //Item testItem = new Item("test", "test", 0, 0);
            Debug.Assert(testItem.GetName() == "test");
            Debug.Assert(testItem.GetTag() == "test");
            Debug.Assert(testItem.GetAttackDamage() == 0);
            Debug.Assert(testItem.GetHpEffect() == 0);
        }

        public void TestPlayer()
        {
            //Player testPlayer = new Player("test", 0);
            Debug.Assert(testPlayer.GetName() == "test");
            Debug.Assert(testPlayer.GetHealth() == 0);
            Debug.Assert(testPlayer.GetLevel() == 1);
            Debug.Assert(testPlayer.GetXp() == 0);
            Debug.Assert(testPlayer.GetLocation() == 1);
            Debug.Assert(testPlayer.AddItem("Test Item"));
            Debug.Assert(testPlayer.RemoveItem("Test Item"));
            Debug.Assert(testPlayer.GetInventoryContents() == "Test Item");
        }
    }
}
