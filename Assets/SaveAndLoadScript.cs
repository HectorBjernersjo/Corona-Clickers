using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndLoadScript : MonoBehaviour
{
   public static float LoadTimeSeconds;
   public static float SecondsOffline;
   public static DateTime TimeZero = new DateTime(2021,1,1);

   public GameObject OfflinePanel;
   public Text OfflineText;

   void Update()
   {
      
   }

   void Start()
   {
      Load();
   }

   void OnApplicationQuit() 
   {
      SaveSystem.SaveGame();
   }



   public void Load()
   {
      GameData data = SaveSystem.LoadGame();

      SetInfectedVariables(data);
      SetAscendVariables(data);
      SetBuildingVars(data);
      SetAscensionUppgradeVars(data);
      InfectOffline(data);

      Ascension.IpsUpgradeMultiplier = data.IpsUpgradeMultiplier;
      Ascension.IptUpgradeMultiplier = data.IptUpgradeMultiplier;
      Discount.TapCostMultiplier = data.TapCostMultiplier;
      Discount.TimeCostMultiplier = data.TimeCostMultiplier;
      BiotechBusiness.BiotechBusinessMultiplier = data.BioTechBusinessMultiplier;

      TapCombo.IsActive = data.TapComboIsActive;  

      Boost.BoostSecondsLeft = data.BoostSecondsLeft - SecondsOffline;
      if (Boost.BoostSecondsLeft > 0)
         Boost.Instance.BoostSlider.gameObject.SetActive(true);

      }

   private void SetAscendVariables(GameData data)
   {
      Ascension.AscensionPoints = data.Ascension_Points;
      Ascension.SpentPoints = data.AscensionPointsSpent;
   }


   private void SetBuildingVars(GameData data)
   {
      for (var i = 0; i < BuildingHandler.BuildingList.Count; i++)
      {
         var building = BuildingHandler.BuildingList[i];
         building.CurrentCost = data.BuildingCosts[i]; 
         building.NrBought = data.BuildingAmounts[i];
      }
   }

   private void SetAscensionUppgradeVars(GameData data)
   {
      for (var i = 0; i < AscensionUpgradeHandler.AscensionUpgrades.Count; i++)
      {
         var upgrade = AscensionUpgradeHandler.AscensionUpgrades[i];
         upgrade.Owned = data.AscensionUpgradesOwned[i];
         if (upgrade.Owned)
            upgrade.GetComponent<Image>().color = AscensionUpgrade.OwnedGreen;
      }

      BiotechResearch.BiotechResearchMultiplier = data.BioTechResearchMultiplier;
   }

   private void SetInfectedVariables(GameData data)
   {
      InfectedScript.Infected = data.Infected;
      InfectedScript.InfectedEver = data.InfectedThisAscension;
   }


   private void InfectOffline(GameData data)
   {
      var infectedBeforeOfflineEarnings = InfectedScript.Infected;

      LoadTimeSeconds = (float)(DateTime.Now - TimeZero).TotalSeconds;
      SecondsOffline = LoadTimeSeconds - data.SaveTimeSeconds;


      if (data.BoostSecondsLeft > SecondsOffline)
      {
         InfectedScript.Infect(seconds: SecondsOffline * 2, ignoreBoost: true);
      }

      if (data.BoostSecondsLeft < SecondsOffline && data.BoostSecondsLeft > 0)
      {
         InfectedScript.Infect(seconds:data.BoostSecondsLeft, ignoreBoost:true);
         InfectedScript.Infect(seconds:SecondsOffline);
      }
      if(data.BoostSecondsLeft <= 0)
      {
         InfectedScript.Infect(seconds: SecondsOffline, ignoreBoost:true);
      }

      var offlineEarnings = InfectedScript.Infected - infectedBeforeOfflineEarnings;

      if (data != null)
      {
         OfflinePanel.SetActive(true);
         OfflineText.text = PengaNamn.FormateraMedEnhet(offlineEarnings); 
      }

   }
}
