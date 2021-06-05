using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

[System.Serializable]
public class GameData
{
   public float Infected;
   public float InfectedPerSec;
   public float InfectedPerTap;
   public float[] KoffCosts;
   public int[] KoffAmounts;

   public float SaveTimeSeconds;

   public GameData()
   {

      Infected = InfectedScript.Infected;
      InfectedPerSec = InfectedScript.InfectedPerSec;
      InfectedPerTap = InfectedScript.InfectedPerTap;

      KoffCosts = SaveAndLoadScript.KoffList.Select(k => k.Cost).ToArray();
      KoffAmounts = SaveAndLoadScript.KoffList.Select(k => k.NrOfKoffs).ToArray();

      SaveTimeSeconds = (float) (DateTime.Now - SaveAndLoadScript.TimeZero).TotalSeconds;
   }

}
