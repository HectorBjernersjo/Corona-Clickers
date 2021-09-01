using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Cooperation : AscensionUpgrade
{
   public static bool IsActive => Instance.Owned;
   public Text PercentIncreaseText;
   public static Cooperation Instance;
   public override void SetVariables()
   {

   }

   public Cooperation()
   {
      Instance = this;
   }




   public override void SpecialBuyStuff()
   {
      
   }

   void Update()
   {
      UpdateUi();
   }

   public override void UpdateUi()
   {
      if (Owned && Math.Log10(InfectedScript.GetInfectedPerSec()) > 0)
         PercentIncreaseText.text = "Current Boost: " + Math.Round(Math.Log10(InfectedScript.GetInfectedPerSec()), 2) * 100 + "%";
      else if (Math.Log10(InfectedScript.GetInfectedPerSec()) > 0)
         PercentIncreaseText.text = "Possible Boost: " + Math.Round(Math.Log10(InfectedScript.GetInfectedPerSec()), 2) * 100 + "%";
   }
}
