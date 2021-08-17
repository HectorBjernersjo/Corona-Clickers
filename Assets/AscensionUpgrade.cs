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


   void Start()
   {
      SetVariables();
      CostText = GetComponentsInChildren<Text>(includeInactive:true).First(t => t.name == "Cost");
      UpdateText();
   }

   public virtual void SetVariables()
   {
      
   }

   public void Buy()
   {
      if (Ascension.AscensionPoints >= Cost && !Owned)
      {
         Ascension.AscensionPoints -= Cost;
         Ascension.SpentPoints += Cost;
         Owned = true;
         SpecialBuyStuff();
         UpdateText();
         GetComponent<Image>().color = Color.green;
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
