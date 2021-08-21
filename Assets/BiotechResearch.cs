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
      Cost = 1;
      CurrentBoostText.text = "Current Boost: " + ((BiotechResearchMultiplier - 1) * 100).ToString("00.00") + "%";
   }

   public override void SpecialBuyStuff()
   {
      BiotechResearchMultiplier *= 1.02;
      CurrentBoostText.text = "Current Boost: " + ((BiotechResearchMultiplier - 1) * 100).ToString("00.00") + "%";
   }
}
