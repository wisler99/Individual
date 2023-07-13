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
            if (string.IsNullOrEmpty(json) == false) //  문자열이 비어있으면 true  뭔가 있으면 false
            {
                _itemTable = JsonUtility.FromJson<ItemDataTable>(json);

            }
            else
            {
                Debug.Log("파일이 없습니다.");
            }
        }
        else
        {
            Debug.Log("파일이 없습니다.");
        }
    } // 아이템 데이터 Json파일을 로드

    void SearchItemID(int _dropItemID) // 아이템 아이디를 통해서 어떤 아이템인지 검색
    {
        foreach(var itemID in _itemTable._itemTable)
        {
            
        }
    }

}


# region 아이템 데이터 테이블
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
