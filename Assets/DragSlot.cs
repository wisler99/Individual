using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragSlot : MonoBehaviour
{
    public static DragSlot Instance;
    public Slot _dragSlot;

    int _itemID;
    public int ItemID
    {
        get { return _itemID; }
        set { _itemID = value; }
    }
    ItemType _itemType;
    public ItemType ItemType
    {
        get { return _itemType; }
        set { _itemType = value; }
    }
    private void Awake()
    {
        Instance = this;
    }

    public void setItemData(int itemId, Image _itemImage)
    {
        gameObject.GetComponent<Image>().sprite = _itemImage.sprite;
        ItemID = itemId;
        ItemType = Data.Instance.SearchType(itemId);
    }

}
