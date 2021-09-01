using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostEarningUpgrade : AscensionUpgrade
{
   public static float BoostEarningMultiplier
   {
      get
      {
         var boostEarningMultiplier = 2;

         if (Instance.Owned)
            boostEarningMultiplier = 10;

         return boostEarningMultiplier;
      }
   }

   public static BoostEarningUpgrade Instance;
   public override void SetVariables()
   {
      Cost = 15;
   }
   public BoostEarningUpgrade()
   {
      Instance = this;
   }

   public override void SpecialBuyStuff()
   {
      if (Boost.BoostSecondsLeft >= Boost.BoostSecondsLeft * BoostTimeUpgrade.BoostTimeMultiplier)
         Boost.BoostSecondsLeft *= BoostTimeUpgrade.BoostTimeMultiplier;
   }
}
