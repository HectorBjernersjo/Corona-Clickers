using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooperation : AscensionUpgrade
{
   public static bool IsActive;
   public Text PercentIncreaseText;
   public override void SetVariables()
   {
      
   }

   public override void SpecialBuyStuff()
   {
      IsActive = true;
   }

   void Update()
   {
      UpdateUi();
   }

   public override void UpdateUi()
   {
      if (IsActive && Math.Log10(InfectedScript.GetInfectedPerSec()) > 0)
         PercentIncreaseText.text = "Current Boost: " + Math.Round(Math.Log10(InfectedScript.GetInfectedPerSec()), 2) * 100 + "%";
      else if (Math.Log10(InfectedScript.GetInfectedPerSec()) > 0)
         PercentIncreaseText.text = "Possible Boost: " + Math.Round(Math.Log10(InfectedScript.GetInfectedPerSec()), 2) * 100 + "%";
   }
}
