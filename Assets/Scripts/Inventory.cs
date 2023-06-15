using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image _inventoryImage;
    private void Start()
    {
        gameObject.SetActive(false);
    }



    public void InventoryOpen()
    {
        if (gameObject.activeSelf == false) gameObject.SetActive(true);
        else
        {
            gameObject.SetActive(false);
        }
    }


}
