using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField]Image _itmeImage;
    [SerializeField] Text _countText;

    int _itemID;
    public int itemID
    {
        get { return _itemID; }
        set { _itemID = value; }
    }

    int _itemCount;
    public int itemCount
    {
        get { return _itemCount; }
        set { _itemCount = value; }
    }

    public void Init(int itemID, Sprite spr)
    {
        _itemID = itemID;
        _itmeImage.sprite = spr;
        SlotUpdate(1);
    }

    public void SlotUpdate(int count)
    {
        _itemCount += count;
        _countText.text = _itemCount.ToString();
        if(_itemCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
