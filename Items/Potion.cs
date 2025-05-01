using System;

namespace DungeonExplorer
{
    /// <summary>
    /// A class representing a potion in the text-based adventure.
    /// </summary>
    /// <remarks> The Potion class inherits from the Item class and implements the IConsumable interface. </remarks>
{
    public class Potion : Item, IConsumable
    {
        public int hpEffect;
        private string tag;

        /// <summary>
        /// Initializes a new instance of the <see cref="Potion"/> class.
        /// </summary>
        /// <param name="name">The name of the potion.</param>
        /// <param name="effect">The HP effect of the potion.</param>
        public Potion(string name, int effect) : base(name)
        {
            this.hpEffect = effect;
        }

        /// <summary> Gets the potion's HP effect. </summary>
        public int GetHpEffect()
        {
            return this.hpEffect;
        }
    }
}
