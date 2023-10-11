using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    private static Data instance = null;

    ItemDataTable _itemTable;

    AsyncOperation _asyncOperation;

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        _itemTable = new ItemDataTable();
        _itemTable._itemTable = new List<ItemData>();

        StartCoroutine(LoadGame());
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
    #region ������ �ε�
    public event EventHandler LoadingEnd;
    public IEnumerator LoadGame()
    {
        RoadItemTable();
        yield return null;

        // �������� �ʿ��� ��� ���ӵ����͸� �ε尡�Ǹ� gmaeScene�ε�
        _asyncOperation = SceneManager.LoadSceneAsync("GameScene");
        _asyncOperation.allowSceneActivation = false;

        while (true)
        {
            if (_asyncOperation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(3f);
                LoadingEnd?.Invoke(this, EventArgs.Empty);
                break;
            }
            yield return null;
        }
    }
    public void SceneChange()
    {
        StopCoroutine(LoadGame());
        _asyncOperation.allowSceneActivation = true;
        GameManager.Instance.isGameScene = true;
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

    #endregion

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


# region ������ ������ ���̺�
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
