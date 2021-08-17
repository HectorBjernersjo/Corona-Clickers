using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InfectedScript : MonoBehaviour
{
   public static double Infected;
   public static double InfectedEver;

   public static Text InfectedText;
   public static Text InfectedPerSecText;

   private CoronaAnimator coronaAnimator;

   private void Start()
   {
      coronaAnimator = GetComponentInChildren<CoronaAnimator>();
   }

   private void Update()
   {
      Infect(seconds:Time.deltaTime);
   }
   public void InfectClick()
   {
      Infect(GetInfectedPerTap());
      if(TapCombo.IsActive)
         TapCombo.ToDoWhenClick();
      coronaAnimator.ClickAnimation();
   }

   public static double GetInfectedPerSec(bool ignoreBoost = false)
   {
      double infectedPerSec = 0;

      foreach (var building in BuildingHandler.BuildingList)
      {
         infectedPerSec += building.NrBought * building.IncreaseInfectedPerSec;
      }

      if (!ignoreBoost)
         if(Boost.BoostSecondsLeft > 0)
            infectedPerSec *= 2;

      infectedPerSec *= Ascension.IPSUpgradeMultiplier;

      return infectedPerSec;
   }

   public static double GetInfectedPerTap()
   {
      double infectedPerTap = 1;

      foreach (var building in BuildingHandler.BuildingList)
      {
         infectedPerTap += building.NrBought * building.IncreaseInfectedPerTap;
      }

      infectedPerTap *= Ascension.IPTUpgradeMultiplier;
      infectedPerTap *= TapCombo.TapMultiplier;

      return infectedPerTap;
   }


   public static void Infect(double nrInfected = 0, float seconds = 0, bool ignoreBoost = false)
   {
      double toInfect = 0;

      toInfect += nrInfected;
      toInfect += seconds * GetInfectedPerSec(ignoreBoost);
      
      //if (boost)
      //{
      //   toInfect += nrInfected * 2;
      //   toInfect += seconds * InfectedPerSecNoBoost * 2;
      //}
      //else
      //{
      //   toInfect += nrInfected;
      //   toInfect += seconds * InfectedPerSecNoBoost;
      //}

      Ascension.InfectedHasIncreased(toInfect);
      Infected += toInfect;
      InfectedEver += toInfect;

      UpdateInfectedTexts();
   }

   private static void UpdateInfectedTexts()
   {
      if (InfectedText == null)
      {
         InfectedText = GameObject.Find("InfectedText").GetComponent<Text>();
         InfectedPerSecText = GameObject.Find("InfectedPerSecText").GetComponent<Text>();
      }
      InfectedText.text = "infected: " + PengaNamn.FormateraMedEnhet(Infected, true); 


      InfectedPerSecText.text = PengaNamn.FormateraMedEnhet(GetInfectedPerSec(), true) + " Infected per second";
   }
}
