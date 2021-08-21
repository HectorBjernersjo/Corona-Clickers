using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AscensionUpgrade : MonoBehaviour
{
   internal double Cost;
   internal bool Owned;

   public Text CostText;

   public static Color OwnedGreen = new Color(99 / 255f, 199 / 255f, 77/255f);

   void Start()
   {
      SetVariables();
      CostText = GetComponentsInChildren<Text>(includeInactive:true).First(t => t.name == "Cost");
      UpdateText();
   }

   public virtual void SetVariables()
   {
      
   }

   public void Buy(bool canBeBoughtMultipleTimes = false)
   {
      if (Ascension.AscensionPoints >= Cost && (!Owned || canBeBoughtMultipleTimes))
      {
         Ascension.AscensionPoints -= Cost;
         Ascension.SpentPoints += Cost;
         Owned = true;
         SpecialBuyStuff();
         UpdateText();
         GetComponent<Image>().color = OwnedGreen;
      }
   }

   public void UpdateText()
   {
      CostText.text = Cost.ToString();
   }

   public virtual void SpecialBuyStuff()
   {
      
   }
}
