using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    ItemData _itemData;
    [SerializeField] int itemID;

    private void Start()
    {
        _itemData = new ItemData( 1);
        _itemData._itemID = itemID;
    }

    public ItemData GetItem()
    {
        Debug.Log(_itemData._itemID);
        Debug.Log(_itemData._itemType);
        Destroy(gameObject);
        return _itemData; 
    }
}
