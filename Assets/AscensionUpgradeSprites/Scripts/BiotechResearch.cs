using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BiotechResearch : AscensionUpgrade
{
   public static double BiotechResearchMultiplier => Math.Pow(1.05, Instance.NrOwned);
   public static BiotechResearch Instance;
   public Text CurrentBoostText;

   public BiotechResearch()
   {
      Instance = this;
   }

   public override void SetVariables()
   {
      UpdateUi();
   }

   public override void SpecialBuyStuff()
   {
      UpdateUi();
   }

   public override void UpdateUi()
   {
      CurrentBoostText.text = "Current Boost: " + ((BiotechResearchMultiplier - 1) * 100).ToString("00.00") + "%";
   }
}
