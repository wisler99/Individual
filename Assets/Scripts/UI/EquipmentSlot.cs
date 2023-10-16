using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] GameObject _itemImage;
    [SerializeField] GameUI _gameUI;

    bool _isActive;

    int _itemID;
    public int itemID
    {
        get
        {
            return _itemID;
        }
        set
        {
            _itemID = value;
        }
    }

    Sprite _itemIcon;
    public Sprite itemIcon
    {
        get
        {
            return _itemIcon;
        }
        set
        {
            _itemIcon = value;
        }
    }
    private void Start()
    {
        _isActive = false;
    }
    private void Update()
    {
        if (_isActive) _itemImage.gameObject.SetActive(true);
        else _itemImage.gameObject.SetActive(false);
    }

    public void Drop(BaseEventData data)
    {
        DragSlot ds = DragSlot.Instance;
        if(ds.ItemType == ItemType.tool)
        {
            _isActive = true;
            _itemImage.GetComponent<Image>().sprite = ds.gameObject.GetComponent<Image>().sprite;
            _itemIcon = ds.gameObject.GetComponent<Image>().sprite;
            _itemID = ds.ItemID;
            _itemImage.SetActive(true);
            _gameUI.UpdateSlot();
            return;
        }
        Debug.Log("장비 아이템만 장착 가능합니다.");

    }
}
