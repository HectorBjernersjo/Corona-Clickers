using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndLoadScript : MonoBehaviour
{
   public static List<KoffScript> KoffList = new List<KoffScript>();

   public static float LoadTimeSeconds;
   public static float SecondsOffline;
   public static DateTime TimeZero = new DateTime(2021,1,1);

   public GameObject OfflinePanel;
   public Text OfflineText;

   void Start()
   {
      foreach (var koff in GetComponentsInChildren<KoffScript>(includeInactive:true))
      {
         KoffList.Add(koff);
      }
      Load();
   }

   void OnApplicationQuit()
   {

      SaveSystem.SaveGame();
   }

   public void Load()
   {
      GameData data = SaveSystem.LoadGame();

      LoadTimeSeconds = (float) (DateTime.Now - TimeZero).TotalSeconds;
      SecondsOffline = (float) LoadTimeSeconds - data.SaveTimeSeconds;

      InfectedScript.Infected = data.Infected;
      InfectedScript.InfectedPerSec = data.InfectedPerSec;
      InfectedScript.InfectedPerTap = data.InfectedPerTap;

      InfectedScript.Infected += SecondsOffline * InfectedScript.InfectedPerSec;

      for (var i = 0; i < KoffList.Count; i++)
      {
         var koff = KoffList[i];
         koff.Cost = data.KoffCosts[i];
         koff.NrOfKoffs = data.KoffAmounts [i];
      }

      if (data != null)
      {
         OfflinePanel.SetActive(true);
         OfflineText.text = (SecondsOffline * InfectedScript.InfectedPerSec).ToString();
      }
   }
}
