using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class Data : MonoBehaviour
{

    ItemDataTable _itemTable;

    private void Start()
    {
        _itemTable = new ItemDataTable();
        _itemTable._itemTable = new List<ItemData>();
        RoadItemTable();

    }
    void Update()
    {

    }

    void RoadItemTable()
    {
        if (File.Exists(Application.persistentDataPath + "/itemdata.josn"))
        {
            string json = "";
            using (StreamReader inStream = new StreamReader(Application.persistentDataPath + "/itemdata.josn"))
            {
                json = inStream.ReadToEnd();
            }
            if (string.IsNullOrEmpty(json) == false) //  ���ڿ��� ��������� true  ���� ������ false
            {
                _itemTable = JsonUtility.FromJson<ItemDataTable>(json);

            }
            else
            {
                Debug.Log("������ �����ϴ�.");
            }
        }
        else
        {
            Debug.Log("������ �����ϴ�.");
        }
    } // ������ ������ Json������ �ε�

    void SearchItemID(int _dropItemID) // ������ ���̵� ���ؼ� � ���������� �˻�
    {
        foreach(var itemID in _itemTable._itemTable)
        {
            
        }
    }

}


# region ������ ������ ���̺�
public enum ItemType
{
    material,
    tool,
    Food,
}
[Serializable]
public class ItemDataTable
{
    public List<ItemData> _itemTable;
}
[Serializable]
public class ItemData
{
    public ItemType _itemType;
    public string _itemName;
    public int _itemID;
    public ItemData(ItemType type, string name, int ID)
    {
        _itemType = type;
        _itemName = name;
        _itemID = ID;
    }
}
#endregion
