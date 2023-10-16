using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSlot : MonoBehaviour
{
    public static SelectSlot Instance;
    int _itemID;
    public int itemID
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

}
