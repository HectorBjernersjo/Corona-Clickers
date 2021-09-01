using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
   internal double NrBought;
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
      if (InfectedScript.Infected >= GetCostForAll(BuyMultiplier.Multiplier))
      {
         InfectedScript.Infected -= GetCostForAll(BuyMultiplier.Multiplier);
         NrBought += BuyMultiplier.Multiplier;

         UpdateTexts();
      }

   }

   private double GetCostForAll(double amountToBuy)
   {
      var costForAll = 0.0;

      for (int i = 0; i < amountToBuy; i++)
      {
         costForAll += GetCostForOne() * Math.Pow(1.1, i);
      }

      return costForAll;
   }

   public double GetCostForOne()
   {
      double currentCostMultiplier;

      if (IncreaseInfectedPerSec > IncreaseInfectedPerTap)
         currentCostMultiplier = TimeDiscount.TimeCostMultiplier;
      else
         currentCostMultiplier = TapDiscount.TapCostMultiplier;

      var cost = StartCost * Math.Pow(1.1, NrBought) * currentCostMultiplier * BiotechBusiness.BiotechBusinessMultiplier;

      return cost;
   }

   public void UpdateTexts()
   {
      //Emmas första accomplishment! :( (nt längre) fast typ ju! fast ne fast jo 
      CostText.text = PengaNamn.FormateraMedEnhet(GetCostForAll(BuyMultiplier.Multiplier));
      NrBoughtText.text = "lvl " + NrBought;

      if (IncreaseInfectedPerSec > IncreaseInfectedPerTap)
      {
         IncreaseText.text = PengaNamn.FormateraMedEnhet(IncreaseInfectedPerSec * BuyMultiplier.Multiplier * Ascension.GetIpsMultiplier(), true);
      }
      else
      {
         IncreaseText.text = PengaNamn.FormateraMedEnhet(IncreaseInfectedPerTap * BuyMultiplier.Multiplier * Ascension.GetIptMultiplier(), true);
      }
   }

   // VÄlkommen hem Emma!
   void Update()
   {



   }
}
