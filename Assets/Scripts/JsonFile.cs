using System.IO;
using UnityEngine;

public class JsonFile : MonoBehaviour
{
    string file;
    private void Start()
    {
        file = Application.persistentDataPath + "/PlayerFile.json";
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 쓰기
            PlayerData pd = new PlayerData(1, "플레이어", 0.4f);
            string saveJson = JsonUtility.ToJson(pd);
            File.WriteAllText(file, saveJson);
        }

        if (Input.GetMouseButtonDown(1))
        {
            // 읽기
            string readJson = File.ReadAllText(file);
            PlayerData pd = JsonUtility.FromJson<PlayerData>(readJson);
            Debug.Log($"num : {pd._iNum} , name : {pd._name}, def {pd._def}");
        }
    }
}

[System.Serializable]
public class PlayerData
{
    public int _iNum;
    public string _name;
    public float _def;
    public PlayerData(int iNum, string name, float def)
    {
        _iNum = iNum;
        _name = name;
        _def = def;
    }
}