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
   public double Infected;
   public double InfectedThisAscension;

   public double InfectedPerSecNoBoost;
   public double InfectedPerTapNoBoost;

   public double[] BuildingCosts;
   public int[] BuildingAmounts;

   public bool[] AscensionUpgradesOwned;

   public bool TapComboIsActive;

   public float SaveTimeSeconds;
   public float BoostSecondsLeft;

   public double Ascension_LeftToNextPoint;
   public double Ascension_Points;

   public GameData()
   {
      Infected = InfectedScript.Infected;
      InfectedThisAscension = InfectedScript.InfectedEver;

      InfectedPerSecNoBoost = InfectedScript.GetInfectedPerSec(ignoreBoost:true);
      InfectedPerTapNoBoost = InfectedScript.GetInfectedPerTap();

      BuildingCosts = BuildingHandler.BuildingList.Select(b => b.CurrentCost).ToArray();
      BuildingAmounts = BuildingHandler.BuildingList.Select(b => b.NrBought).ToArray();

      AscensionUpgradesOwned = AscensionUpgradeHandler.AscensionUpgrades.Select(u => u.Owned).ToArray();

      TapComboIsActive = AscensionUpgradeHandler.TapComboUpgrade.Owned;

      SaveTimeSeconds = (float) (DateTime.Now - SaveAndLoadScript.TimeZero).TotalSeconds;
      BoostSecondsLeft = Boost.BoostSecondsLeft;

      Ascension_Points = Ascension.AscensionPoints;
   }

}
