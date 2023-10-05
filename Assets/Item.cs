using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    ItemData _itemData;
    [SerializeField] int itemID;

    private void Start()
    {
        _itemData = new ItemData(itemID);
        _itemData._itemID = itemID;
    }

    public ItemData GetItem()
    {
        Destroy(gameObject);
        return _itemData; 
    }
}
