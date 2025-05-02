using System;
using System.Runtime.CompilerServices;

namespace DungeonExplorer
{
    public class Item
    {
        private string name;
        private string tag;

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        public Item(string name)
        {
            this.name = name;
            this.tag = tag;
        }

        public string GetName()
        {
            return name;
        }

        public string GetTag()
        {
            return tag;
        }
    }
}


