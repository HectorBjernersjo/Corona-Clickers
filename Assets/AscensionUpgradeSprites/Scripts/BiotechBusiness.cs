using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiotechBusiness : AscensionUpgrade
{
   public static double BiotechBusinessMultiplier => Math.Pow(0.95, Instance.NrOwned);
   public Text DiscountText;
   public static BiotechBusiness Instance;
   public override void SetVariables()
   {
      
      UpdateUi();
   }

   public override void SpecialBuyStuff()
   {
      UpdateUi();
   }

   public BiotechBusiness()
   {
      Instance = this;
   }

   public override void UpdateUi()
   {
      if(BiotechBusinessMultiplier <= 0.01)
         DiscountText.text = "Current TimeDiscount: " + ((1 - BiotechBusinessMultiplier) * 100).ToString("00.00####") + "%";
      else
         DiscountText.text = "Current TimeDiscount: " + ((1 - BiotechBusinessMultiplier) * 100).ToString("00.00") + "%";
   }
}
