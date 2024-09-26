using System.Collections;
using System.Text;
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
        public Sprite icon;
        /// <summary>
        /// price of the item (buying price)
        /// </summary>
        public int price;

        [Header("Scores")]
        public int happiness;
        public int physicalHealth;
        public int mentalHealth;


        public string Description
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (happiness != 0)
                {
                    stringBuilder.Append(Sign(happiness) + " Happiness");
                }
                if (physicalHealth != 0)
                {
                    stringBuilder.Append(Sign(physicalHealth) + " Physical Health");
                }
                if (mentalHealth != 0)
                {
                    stringBuilder.Append(Sign(mentalHealth) + " Mental Health");
                }
                return stringBuilder.ToString();
            }
        }

        private string Sign(int value)
        {
            return value > 0 ? "+" : "-";
        }
    }
}
