using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoffScript : MonoBehaviour
{
   private Text NrKoffstext;
   public int NrOfKoffs;
   public float IncreaseInfectedPerSec = 0.1f;
   public float IncreaseInfectedPerTap;
   public Text InfcPerSectext;
   public float Cost;
   public Text CostText;
   public Text Increasetext;



   // Start is called before the first frame update
   void Start()
   {
      UpdateTexts();
      var MostlyUselessTextList = this.GetComponentsInChildren<Text>();

      foreach (Text text in MostlyUselessTextList)
      {
         if (text.gameObject.name == "NrBought")
         {
            NrKoffstext = text;
         }
      }

   }

   public void BuyKoff()
   {
      if (InfectedScript.Infected >= Cost)
      {
         InfectedScript.InfectedPerSec += IncreaseInfectedPerSec;
         InfectedScript.InfectedPerTap += IncreaseInfectedPerTap;

         NrOfKoffs += 1;
         InfectedScript.Infected -= Cost;
         NrKoffstext.text = NrOfKoffs + " koffs";

         Cost = (float) Math.Round(Cost * 1.1);

         UpdateTexts();
      }

      Ads.ShowAD();
   }

   public void UpdateTexts()
   {
      InfcPerSectext.text = Math.Round(InfectedScript.InfectedPerSec, 1) + " Infected per second";
      //Emmas första accomplishment! :( (nt längre) fast typ ju! fast ne fast jo 
      CostText.text = Cost.ToString();

      if (IncreaseInfectedPerSec > IncreaseInfectedPerTap)
      {
         Increasetext.text = "IPS: +" + IncreaseInfectedPerSec.ToString();
      }
      else
      {
         Increasetext.text = "IPT: +" + IncreaseInfectedPerTap.ToString();
      }
   }

   // VÄlkommen hem Emma!
   void Update()
   {



   }
}
