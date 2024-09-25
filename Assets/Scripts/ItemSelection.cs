using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OneButton
{
    public class ItemSelection : MonoBehaviour
    {
        public Image image;
        public TMP_Text nameText;
        public int id;

        public Color selectColor;
        public Color unselectColor;
        //public bool isItem1;
        //public bool isItem2;
        //public bool isSkip;
        //private bool item1_selected = true;
        //private bool item2_selected = false;
        //private bool skip_selected = false; 

        public void Setup(ItemData item)
        {
            image.sprite = item.icon;
            nameText.text = item.itemName;
        }

        public void Toggle(int currentSelection)
        {
            if (currentSelection == id)
            {
                image.color = selectColor;
            }
            else
            {
                image.color = unselectColor;
            }
        }

        //void ShowSelected()
        //{
        //    if (item1_selected && isItem1)
        //    {
        //        image.color = Color.cyan;
        //    }
        //    else if (item2_selected && isItem2)
        //    {
        //        image.color = Color.cyan;
        //    }
        //    else if (skip_selected && isSkip)
        //    {
        //        image.color = Color.cyan;
        //    }
        //    else
        //    {
        //        image.color = Color.gray;
        //    }
        //}
    }
}