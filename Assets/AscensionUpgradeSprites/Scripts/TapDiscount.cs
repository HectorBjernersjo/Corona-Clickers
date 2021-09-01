using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapDiscount : AscensionUpgrade
{
   public static double TapCostMultiplier
   {
      get
      {
         double tapCostMultiplier = 1;

         if (Instance.Owned)
            tapCostMultiplier *= 0.1;

         return tapCostMultiplier;
      }
   }

   public static TapDiscount Instance;

   public TapDiscount()
   {
      Instance = this;
   }

   public override void SetVariables()
   {
      
   }

}
