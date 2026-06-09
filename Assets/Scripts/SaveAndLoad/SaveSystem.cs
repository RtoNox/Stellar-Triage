using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
   
    public static void SavePlayer(GameManager manager, int slotNumber)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        
        string path = Path.Combine(Application.persistentDataPath, "save" + slotNumber + ".dat");
        
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(manager);

        formatter.Serialize(stream, data);
        stream.Close();
        
        Debug.Log("Game berhasil disimpan di: " + path);
    }


    public static PlayerData LoadPlayer(int slotNumber)
    {
        string path = Path.Combine(Application.persistentDataPath, "save" + slotNumber + ".dat");

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogWarning("File save tidak ditemukan di slot: " + slotNumber);
            return null;
        }
    }
}