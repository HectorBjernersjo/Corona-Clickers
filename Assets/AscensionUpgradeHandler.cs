using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensionUpgradeHandler : MonoBehaviour
{
   public static List<AscensionUpgrade> AscensionUpgrades = new List<AscensionUpgrade>();
   public static TapComboUpgrade TapComboUpgrade;

   // Start is called before the first frame update
   void Start()
    {
      foreach (var building in GetComponentsInChildren<AscensionUpgrade>(includeInactive: true))
      {
         AscensionUpgrades.Add(building);
      }

      TapComboUpgrade = GetComponentInChildren<TapComboUpgrade>(includeInactive: true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
