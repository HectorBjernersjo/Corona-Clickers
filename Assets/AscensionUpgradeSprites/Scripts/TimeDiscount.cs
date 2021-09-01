using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDiscount : AscensionUpgrade
{
   public static double TimeCostMultiplier
   {
      get
      {
         double timeCostMultiplier = 1;

         if (Instance.Owned)
            timeCostMultiplier *= 0.2;

         return timeCostMultiplier;
      }
   }

   public static TimeDiscount Instance;

   public TimeDiscount()
   {
      Instance = this;
   }

   public override void SetVariables()
   {
      
   }

   public override void SpecialBuyStuff()
   {
      
   }

   // Update is called once per frame
   void Update()
   {

   }
}