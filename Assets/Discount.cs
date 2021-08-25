using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discount : AscensionUpgrade
{
   public static double TimeCostMultiplier = 1;
   public static double TapCostMultiplier = 1;

   public override void SetVariables()
   {
      
   }

   public override void SpecialBuyStuff()
   {
      if (this.gameObject.name == "Time Discount")
         TimeCostMultiplier *= 0.2;
      else if(this.gameObject.name =="Tap Discount")
         TapCostMultiplier *= 0.1;
   }

   // Update is called once per frame
   void Update()
   {

   }
}