using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectedScript : MonoBehaviour
{
   public static double Infected;
   public static double InfectedPerTap = 1;
   public static double InfectedPerSec = 0;

   public Text InfectedText;
   public Text Infectedpstext;

   CoronaAnimator coronaAnimator;

   private void Start()
   {
      coronaAnimator = GetComponentInChildren<CoronaAnimator>();
   }

   private void Update()
   {
      //Infecta varje sekund
      
      UpdateInfectedTexts();
      if (Boostbutton.Boost == true)
      {
         Infected += InfectedPerSec * Time.deltaTime * 2;
      }
      else
      {
         Infected += InfectedPerSec * Time.deltaTime;
      }
   }


   public void InfectClick()
   {
      Infected += InfectedPerTap;
      UpdateInfectedTexts();
      coronaAnimator.ClickAnimation();
   }

   private void UpdateInfectedTexts()
   {
      InfectedText.text = "infected: " + Math.Round(Infected).ToString();
      if (Boostbutton.Boost == true)
      {
         Infectedpstext.text = Math.Round(InfectedScript.InfectedPerSec * 2) + " Infected per second";
      }
      else
      {
         Infectedpstext.text = Math.Round(InfectedScript.InfectedPerSec) + " Infected per second";
      }
   }
}
