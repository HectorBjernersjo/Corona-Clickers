using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiotechBusiness : AscensionUpgrade
{
   public static double BiotechBusinessMultiplier = 1;
   public Text DiscountText;
   public override void SetVariables()
   {
      Cost = 1;
      UpdateUi();
   }

   public override void SpecialBuyStuff()
   {
      BiotechBusinessMultiplier = BiotechBusinessMultiplier * 0.98;
      UpdateUi();
   }

   public void UpdateUi()
   {
      if(BiotechBusinessMultiplier <= 0.01)
         DiscountText.text = "Current Discount: " + ((1 - BiotechBusinessMultiplier) * 100).ToString("00.00####") + "%";
      else
         DiscountText.text = "Current Discount: " + ((1 - BiotechBusinessMultiplier) * 100).ToString("00.00") + "%";
   }
}
