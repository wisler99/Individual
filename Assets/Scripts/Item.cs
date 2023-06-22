using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [SerializeField] string _itemName;
    [SerializeField] int _itemID;
    [SerializeField] Sprite _itemSprite;


    private void Start()
    {
        ItemData id = new ItemData(_itemName, _itemID, _itemSprite);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (CompareTag("Player"))
        {
            Debug.Log("aaaa");
        }
    }
    enum ItemType
    {
        Equipment,
        Food,
        Material,
    }
}

class ItemData
{
    string _itemName;
    int _itemID;
    Sprite _itemSprit;

    public ItemData(string name, int id, Sprite sp)
    {
        _itemName= name;
        _itemID= id;
        _itemSprit= sp;
    }

}

