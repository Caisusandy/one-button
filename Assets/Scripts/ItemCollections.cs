using System.Collections.Generic;
using UnityEngine;

namespace OneButton
{
    /// <summary>
    /// A collection of the items of the game, use to store the items in each turn
    /// </summary>
    [CreateAssetMenu(menuName = "Assets/Item Collections")]
    public class ItemCollections : ScriptableObject
    {
        public List<SelectionPair> items;
    }
}
