using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSelection : MonoBehaviour
{
    public bool isItem1;
    public bool isItem2;
    public bool isSkip;
    private bool item1_selected = true;
    private bool item2_selected = false;
    private bool skip_selected = false;
    private Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();

        ShowSelected();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("space"))
        {
            if (item1_selected)
            {
                item1_selected = false;
                item2_selected = true;
            }
            else if (item2_selected)
            {
                skip_selected = true;
                item2_selected = false;
            }
            else if (skip_selected)
            {
                skip_selected = false;
                item1_selected = true;
            }

            ShowSelected();
        }
    }

    void ShowSelected()
    {
        if (item1_selected && isItem1)
        {
            renderer.material.color = Color.cyan;
        }
        else if (item2_selected && isItem2)
        {
            renderer.material.color = Color.cyan;
        }
        else if (skip_selected && isSkip)
        {
            renderer.material.color = Color.cyan;
        }
        else
        {
            renderer.material.color = Color.gray;
        }
    }
}
