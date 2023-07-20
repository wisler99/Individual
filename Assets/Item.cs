using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    ItemData _itemData = new ItemData(ItemType.Food , "µ¹" , 1);

    public ItemData GetItem()
    {
        Debug.Log(_itemData._itemID);
        Debug.Log(_itemData._itemName);
        Debug.Log(_itemData._itemType);
        Destroy(gameObject);
        return _itemData; 
    }
}
