using System;

namespace DungeonExplorer
{
    interface IPlayable
    {
        private readonly List<string> inventory = new List<string>();
        void GetInventoryContents();
    }
}
