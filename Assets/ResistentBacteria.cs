using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistentBacteria : AscensionUpgrade
{
   public override void SetVariables()
   {
      
   }
   public override void SpecialBuyStuff()
   {
      Ascension.IpsUpgradeMultiplier *= 10;
   }
}
