using System.Collections;
using UnityEngine;

namespace OneButton
{
    /// <summary>
    /// Class holding item information
    /// </summary>
    [CreateAssetMenu(menuName = "Assets/Item Data")]
    public class ItemData : ScriptableObject
    {
        public string itemName;
        /// <summary>
        /// price of the item (buying price)
        /// </summary>
        public int price;
        /// <summary>
        /// score value
        /// </summary>
        public int value;
        public Sprite icon;

        public string description;
    }
}
