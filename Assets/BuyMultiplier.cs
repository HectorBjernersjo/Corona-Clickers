using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMultiplier : MonoBehaviour
{
   public static int Multiplier = 1;
   public Text x1Text;
   public Text x10Text;
   public Text x100Text;
   public List<Text> Textlist = new List<Text>();

   void Start()
   {
      Textlist.Add(x1Text);
      Textlist.Add(x10Text);
      Textlist.Add(x100Text);
   }


    public void SetBuyMultiplier(int multiplier)
    {
       Multiplier = multiplier;

       foreach (var text in Textlist)
       {
          text.color = new Color(1,1,1,0.6f);
          text.GetComponentInChildren<RawImage>(includeInactive: true).gameObject.SetActive(false);
       }

       var ActivemultiplierText = x1Text;

      if (multiplier == 10)
         ActivemultiplierText = x10Text;
      if (multiplier == 100)
         ActivemultiplierText = x100Text;

      ActivemultiplierText.color = new Color(1,1,1,1);
      ActivemultiplierText.GetComponentInChildren<RawImage>(includeInactive:true).gameObject.SetActive(true);

      foreach (var building in BuildingHandler.BuildingList)
      {
         building.UpdateTexts();
      }
    }
}
