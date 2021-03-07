using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoffScript : MonoBehaviour
{
        private Text NrKoffstext;
   public int NrOfKoffs;
   public double IncreaseInfectedPerSec = 0.1;
    public double IncreaseInfectedPerTap;
   public Text InfcPerSectext;
    public double Cost;
    public Text CostText;

    // Start is called before the first frame update
    void Start()
   {
        CostText.text = Cost.ToString(); 
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
         UpdateInfcPerSecText();
      }
   }

   public void UpdateInfcPerSecText()
   {
      InfcPerSectext.text = Math.Round(InfectedScript.InfectedPerSec, 1) + " Infected per second";
      //Emmas f�rsta accomplishment! :( (nt l�ngre) fast typ ju! fast ne fast jo 

   }

    // V�lkommen hem Emma!
    void Update()
    {
       
      
      
    }
}
 