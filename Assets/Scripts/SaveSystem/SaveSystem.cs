
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{

    #region CustomStaticMethods

    public static void SavePlayer(GameManager player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        string path = Application.persistentDataPath + "/player.dat";
        FileStream stream = new FileStream(path,FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream,data);
        
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.dat";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);    
            GameManager player = GameManager.Instance;
            SavePlayer(player);
            return null;
        }
    }

    #endregion

}
