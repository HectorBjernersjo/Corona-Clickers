using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
   internal int NrBought;
   public double IncreaseInfectedPerSec;
   public double IncreaseInfectedPerTap;

   public double StartCost;
   internal double CurrentCost;

   public Text NrBoughtText;
   public Text CostText;
   public Text IncreaseText;




   // Start is called before the first frame update
   void Start()
   {
      UpdateTexts();
   }

   public void Buy()
   {
      if (InfectedScript.Infected >= CurrentCost)
      {
         NrBought += 1;
         InfectedScript.Infected -= CurrentCost;

         CurrentCost = Math.Round(CurrentCost * 1.1);

         UpdateTexts();
      }

   }

   public void UpdateTexts()
   {
      //Emmas första accomplishment! :( (nt längre) fast typ ju! fast ne fast jo 
      CostText.text = PengaNamn.FormateraMedEnhet(CurrentCost);
      NrBoughtText.text = "lvl " + NrBought;

      if (IncreaseInfectedPerSec > IncreaseInfectedPerTap)
      {
         IncreaseText.text = PengaNamn.FormateraMedEnhet(IncreaseInfectedPerSec, true);
      }
      else
      {
         IncreaseText.text = PengaNamn.FormateraMedEnhet(IncreaseInfectedPerTap, true);
      }
   }

   // VÄlkommen hem Emma!
   void Update()
   {



   }
}
