using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class Data : MonoBehaviour
{
    private static Data instance = null;

    ItemDataTable _itemTable;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            //씬 전환이 되더라도 파괴되지 않게 한다.
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //만약 씬 이동이 되었는데 그 씬에도 Hierarchy에 GameMgr이 존재할 수도 있다.
            //그럴 경우엔 이전 씬에서 사용하던 인스턴스를 계속 사용해주는 경우가 많은 것 같다.
            //그래서 이미 전역변수인 instance에 인스턴스가 존재한다면 자신을 삭제해준다.
            Destroy(this.gameObject);
        }

    }
    private void Start()
    {
        _itemTable = new ItemDataTable();
        _itemTable._itemTable = new List<ItemData>();
        RoadItemTable();
    }
    void Update()
    {

    }

    public static Data Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
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

    public ItemType SearchType(int _itemID)
    {
        for(int i = 0; _itemTable._itemTable.Count > 0; i++)
        {
            if (_itemTable._itemTable[i]._itemID == _itemID)
            {
                return _itemTable._itemTable[i]._itemType;
            }
        }
        return ItemType.None;
    }

}


# region 아이템 데이터 테이블
public enum ItemType
{
    material,
    tool,
    Food,
    None,
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
    public int _itemID;
    public int _itemCount;
    public ItemData(int ID)
    {
        _itemID = ID;
        _itemCount = 1;
    }
}
#endregion
