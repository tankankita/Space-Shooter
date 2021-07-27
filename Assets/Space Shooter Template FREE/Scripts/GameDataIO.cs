using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataIO 
{
   public const string FILENAME = "gameData.json";

   public static void SaveGameData(GameData data)
   {
        string path = Application.persistentDataPath + "/" + FILENAME;
        Debug.Log("Saving data to "+ path);
        string json = JsonUtility.ToJson(data);
        Debug.Log("Json data: " + json);

        File.WriteAllText(path, json);
    }

    public static GameData LoadGameData()
    {
        string path = Application.persistentDataPath + "/" + FILENAME;
        Debug.Log("Reading data from" + path);

        if(File.Exists(path))
        {
            string loadString = File.ReadAllText(path);
            return JsonUtility.FromJson<GameData>(loadString);
        } else
        {
            Debug.Log("File not found at " + path);
        }

        return null;
    }

     
}
