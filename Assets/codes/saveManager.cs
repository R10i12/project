using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class saveManager : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/save.json";
    }

    public void SaveGame(Transform playerTransform, int currentHealth, int credits)
    {
        SaveData data = new SaveData
        {
            playerX = playerTransform.position.x,
            playerY = playerTransform.position.y,
            playerZ = playerTransform.position.z,
            currentHealth = currentHealth,
            credits = credits
        };

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, json);
    }

    public SaveData LoadGame()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            return JsonUtility.FromJson<SaveData>(json);
        }

        return null;
    }
}

