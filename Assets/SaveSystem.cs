using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
   public static void SaveGame()
   {
      BinaryFormatter formatter = new BinaryFormatter();
      string path = Application.persistentDataPath + "/coronaClicker.txt";
      FileStream stream = new FileStream(path, FileMode.Create);

      GameData data = new GameData();

      formatter.Serialize(stream, data);
      stream.Close();
   }

   public static GameData LoadGame()
   {
      string path = Application.persistentDataPath + "/coronaClicker.txt";
      if (File.Exists(path))
      {
         BinaryFormatter formatter = new BinaryFormatter();
         FileStream stream = new FileStream(path, FileMode.Open) {Position = 0};


         GameData data = (GameData) formatter.Deserialize(stream);
         stream.Close();

         return data;
      }
      else
      {
         Debug.Log("Loading error from path: " + path);
         return null;
      }
   }
}
