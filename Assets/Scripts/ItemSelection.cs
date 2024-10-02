using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OneButton
{

    public class ItemSelection : MonoBehaviour
    {
        public ItemData itemData;
        public Image image;
        public Image bg;
        public TMP_Text nameText;
        public int id;

        public Color selectColor;
        public Color unselectColor;

        public void Setup(ItemData item)
        {
            itemData = item;
            image.sprite = item.icon;
            nameText.text = $"{item.itemName} ${item.price}\n{item.Description}";
        }

        public void Toggle(int currentSelection)
        {
            if (currentSelection == id)
            {
                bg.color = selectColor;
                bg.enabled = true;
            }
            else
            {
                bg.color = unselectColor;
                bg.enabled = false;
            }
        }
    }
}