using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatCodes : MonoBehaviour
{
   void Update()
   {
      if (Input.GetKey("left ctrl") && Input.GetKeyDown("i"))
         InfectedScript.Infect(1000000);

      if (Input.GetKey("left ctrl") && Input.GetKeyDown("d"))
         InfectedScript.Infect(InfectedScript.Infected * 9);

      if (Input.GetKey("left ctrl") && Input.GetKeyDown("r"))
         CompletlyRestart();

      if (Input.GetKey("left ctrl") && Input.GetKeyDown("a"))
      {
         Ascension.AscensionPoints += 10;
         Ascension.UpdateTexts();
      }

   }

   public static void CompletlyRestart()
    {
       Ascension.AscendRestart();
       InfectedScript.InfectedEver = 0;
       Ascension.AscensionPoints = 0;
       Ascension.PossiblePoints = 0;
       Ascension.SpentPoints = 0;
       Ascension.UpdateTexts();
       Ascension.IpsUpgradeMultiplier = 1;
       Ascension.IptUpgradeMultiplier = 1;
       Discount.TapCostMultiplier = 1;
       Discount.TimeCostMultiplier = 1;
       TapCombo.IsActive = false;
       BiotechResearch.BiotechResearchMultiplier = 1;
       BiotechBusiness.BiotechBusinessMultiplier = 1;
       BoostUpgrade.BoostEarningMultiplier = 2;
       BoostUpgrade.BoostTimeMultiplier = 1;
       Boost.BoostSecondsLeft = 0;
       Cooperation.IsActive = false;
       foreach (var upgrade in AscensionUpgradeHandler.AscensionUpgrades)
       {
          upgrade.Owned = false;
          upgrade.GetComponent<Image>().color = Color.white;
       }
    }
}
