using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    int _itemID;
    [SerializeField]Image _itmeImage;
    [SerializeField] Text _countText;
    int _itemCount;

    public void Init(ItemData data, Sprite spr)
    {
        _itemID = data._itemID;
        _itmeImage.sprite = spr;
        SlotUpdate();
    }

    public void SlotUpdate()
    {
        _itemCount++;
        _countText.text = _itemCount.ToString();
    }
}
