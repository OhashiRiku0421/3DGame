using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadSystem
{
    private static SaveLoadSystem _instance = new();

    public static SaveLoadSystem Instance => _instance;

    public void DataSave(List<int> data)
    {
        //Listをラップしてシリアライズする
        ClearStageList<int> clearStageList = new ClearStageList<int>() { List = data };
        string json = JsonUtility.ToJson(clearStageList);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public List<int> DataLoad()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            //Jsonをデシリアライズする
            ClearStageList<int> clearStageList = JsonUtility.FromJson<ClearStageList<int>>(json);
            return clearStageList.List;
        }
        else
        {
            Debug.LogError("セーブデータがありません");
            return null;
        }
    }
}
