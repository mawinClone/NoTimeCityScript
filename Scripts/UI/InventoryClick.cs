using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryClick : MonoBehaviour
{
    public bool isClicked = false;
    public GameObject inventoryPanel;

    public void InventoryOnClick()
    {
        if(!isClicked)
        {
            isClicked = true;
            inventoryPanel.SetActive(true);
        }else{
            isClicked = false;
            inventoryPanel.SetActive(false);
        }
    }

    public void InventoryClose()
    {
        isClicked = false;
        inventoryPanel.SetActive(false);
    }
}
