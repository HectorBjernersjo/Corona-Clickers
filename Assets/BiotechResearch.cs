using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BiotechResearch : AscensionUpgrade
{
   public static double BiotechResearchMultiplier = 1;

   public Text CurrentBoostText;

   public override void SetVariables()
   {
      
      UpdateUi();
   }

   public override void SpecialBuyStuff()
   {
      BiotechResearchMultiplier *= 1.05;
      UpdateUi();
   }

   public override void UpdateUi()
   {
      CurrentBoostText.text = "Current Boost: " + ((BiotechResearchMultiplier - 1) * 100).ToString("00.00") + "%";
   }
}
