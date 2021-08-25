using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostUpgrade : AscensionUpgrade
{
   public static float BoostTimeMultiplier = 1;
   public static float BoostEarningMultiplier = 2;
   public override void SetVariables()
   {
      
   }

   public override void SpecialBuyStuff()
   {
      if (this.gameObject.name == "More Fuel")
         BoostTimeMultiplier *= 4;
      else if (this.gameObject.name == "Boost ...Boost?")
      {
         BoostEarningMultiplier *= 5;
         BoostTimeMultiplier *= 0.5f;
      }

      if (Boost.BoostSecondsLeft >= Boost.BoostSecondsLeft * BoostTimeMultiplier)
         Boost.BoostSecondsLeft *= BoostTimeMultiplier;

   }
}
