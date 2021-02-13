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
   public Text InfcPerSectext;

   // Start is called before the first frame update
   void Start()
   {
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
      if (InfectedScript.Infected >= 20)
      {
         InfectedScript.InfectedPerSec += IncreaseInfectedPerSec;
         NrOfKoffs += 1;
         InfectedScript.Infected -= 20;
         NrKoffstext.text = NrOfKoffs + " koffs";
         UpdateInfcPerSecText();
      }
   }

   public void UpdateInfcPerSecText()
   {
      InfcPerSectext.text = Math.Round(InfectedScript.InfectedPerSec, 1) + " Infected per second";
      //Emmas första accomplishment! :D 
   }

    // VÄlkommen hem Emma!
    void Update()
    {
       
      
      
    }
}
 