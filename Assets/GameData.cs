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
   public double InfectedEver;

   public double IpsUpgradeMultiplier;
   public double IptUpgradeMultiplier;
   public double BioTechResearchMultiplier;
   public double BioTechBusinessMultiplier;
   public double TapCostMultiplier;
   public double TimeCostMultiplier;
   public float BoostTimeMultiplier;
   public float BoostEarningMultiplier;
   public bool CooperationIsActive;

   public double InfectedPerSecNoBoost;
   public double InfectedPerTapNoBoost;

   public double[] BuildingCosts;
   public double[] BuildingAmounts;

   public bool[] AscensionUpgradesOwned;
   public double AscensionPointsSpent;

   public bool TapComboIsActive;

   public float SaveTimeSeconds;
   public float BoostSecondsLeft;

   public double Ascension_LeftToNextPoint;
   public double Ascension_Points;

   public GameData()
   {
      Infected = InfectedScript.Infected;
      InfectedEver = InfectedScript.InfectedEver;

      IpsUpgradeMultiplier = Ascension.IpsUpgradeMultiplier;
      IptUpgradeMultiplier = Ascension.IptUpgradeMultiplier;
      BioTechResearchMultiplier = BiotechResearch.BiotechResearchMultiplier;
      BioTechBusinessMultiplier = BiotechBusiness.BiotechBusinessMultiplier;
      TapCostMultiplier = Discount.TapCostMultiplier;
      TimeCostMultiplier = Discount.TimeCostMultiplier;
      BoostTimeMultiplier = BoostUpgrade.BoostTimeMultiplier;
      BoostEarningMultiplier = BoostUpgrade.BoostEarningMultiplier;
      CooperationIsActive = Cooperation.IsActive;

      InfectedPerSecNoBoost = InfectedScript.GetInfectedPerSec(ignoreBoost:true);
      InfectedPerTapNoBoost = InfectedScript.GetInfectedPerTap();

      BuildingCosts = BuildingHandler.BuildingList.Select(b => b.CurrentCost).ToArray();
      BuildingAmounts = BuildingHandler.BuildingList.Select(b => b.NrBought).ToArray();

      AscensionUpgradesOwned = AscensionUpgradeHandler.AscensionUpgrades.Select(u => u.Owned).ToArray();
      AscensionPointsSpent = Ascension.SpentPoints;

      TapComboIsActive = AscensionUpgradeHandler.TapComboUpgrade.Owned;

      SaveTimeSeconds = (float) (DateTime.Now - SaveAndLoadScript.TimeZero).TotalSeconds;
      BoostSecondsLeft = Boost.BoostSecondsLeft;

      Ascension_Points = Ascension.AscensionPoints;
   }

}
