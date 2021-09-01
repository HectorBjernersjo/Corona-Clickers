using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistentBacteria : AscensionUpgrade
{
   public static double IPSMultiplier
   {
      get
      {
         double ipsMultiplier = 1;

         if (Instance.Owned)
            ipsMultiplier *= 10;

         return ipsMultiplier;
      }
   }

   public static ResistentBacteria Instance;

   public ResistentBacteria()
   {
      Instance = this;
   }
}
