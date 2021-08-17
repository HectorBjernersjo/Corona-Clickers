using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapComboUpgrade : AscensionUpgrade
{
   public override void SetVariables()
   {
      Cost = 20;
   }

   public override void SpecialBuyStuff()
   {
      Debug.Log("det funkar!");
      TapCombo.IsActive = true;
   }
}
