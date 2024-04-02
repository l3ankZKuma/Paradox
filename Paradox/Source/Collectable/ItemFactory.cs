using System;
using Microsoft.Xna.Framework;

namespace Paradox
{
    public class ItemFactory
    {
        public static Items CreateItem(string itemType, Vector2 position)
        {
            switch (itemType)
            {
                case "Coin":
                    return new Coin(position);
                case "Potion":
                    return new Potion(position);
                // Add cases for additional item types as needed
                default:
                    throw new ArgumentException($"Unsupported item type: {itemType}");
            }
        }
    }
}