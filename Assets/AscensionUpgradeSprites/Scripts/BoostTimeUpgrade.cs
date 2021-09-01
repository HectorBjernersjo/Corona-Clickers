using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostTimeUpgrade : AscensionUpgrade
{

   public static BoostTimeUpgrade Instance;

   public static float BoostTimeMultiplier
   {
      get
      {
         float boostTimeMultiplier = 1;
         if (BoostEarningUpgrade.Instance.Owned)
         {
            boostTimeMultiplier /= 2;
         }

         if (Instance.Owned)
         {
            boostTimeMultiplier *= 5;
         }

         return boostTimeMultiplier;
      }
   }

   public BoostTimeUpgrade()
   {
      Instance = this;
   }
   public override void SetVariables()
   {
      Cost = 15;
   }

   public override void SpecialBuyStuff()
   {
      if (Boost.BoostSecondsLeft >= Boost.BoostSecondsLeft * BoostTimeMultiplier)
         Boost.BoostSecondsLeft *= BoostTimeMultiplier;
   }
}
