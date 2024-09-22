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
        public int price;
        public Sprite icon;

        public string description;
    }
}
