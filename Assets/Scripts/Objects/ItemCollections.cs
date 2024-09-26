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
        public List<ItemData> data;
        public List<SelectionPair> items;

        public SelectionPair GetSelectionPair()
        {
            SelectionPair pair = new SelectionPair();
            pair.first = data[UnityEngine.Random.Range(0, data.Count)];
            do
            {
                pair.second = data[UnityEngine.Random.Range(0, data.Count)];
            } while (pair.first == pair.second);
            return pair;
        }
    }
}
