using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistentBacteria : AscensionUpgrade
{
   public override void SetVariables()
   {
      Cost = 10;
   }
   public override void SpecialBuyStuff()
   {
      Ascension.IpsUpgradeMultiplier *= 1.2f;
   }
}
