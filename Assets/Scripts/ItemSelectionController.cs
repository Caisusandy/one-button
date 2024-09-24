using System;
using System.Collections.Generic;
using UnityEngine;

namespace OneButton
{
    public class ItemSelectionController : MonoBehaviour
    {
        public List<ItemSelection> selections;
        public int selection;

        public ItemSelection CurrentSelection => selections[selection];

        internal void Setup(SelectionPair pair)
        {
            selections[0].Setup(pair.first);

        }

        private void Start()
        {
            UpdateSelections();
        }

        private void Update()
        {
            if (Input.GetKeyUp("space"))
            {
                selection++;
                if (selection >= 3) selection = 0;
                UpdateSelections();
            }
        }

        private void UpdateSelections()
        {
            foreach (var item in selections)
            {
                item.Toggle(selection);
            }
        }
    }
}