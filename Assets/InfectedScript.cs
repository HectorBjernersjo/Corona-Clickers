using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectedScript : MonoBehaviour
{
   public static float Infected;
   public static float InfectedPerTap = 1;
   public static float InfectedPerSec = 0;

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
      InfectedText.text = "infected: " + PengaNamn.FormateraMedEnhet((float)Math.Round(Infected));
      if (Boostbutton.Boost == true)
      {
         Infectedpstext.text = PengaNamn.FormateraMedEnhet((float) Math.Round(InfectedScript.InfectedPerSec * 2)) + " Infected per second";
      }
      else
      {
         Infectedpstext.text = PengaNamn.FormateraMedEnhet((float) Math.Round(InfectedScript.InfectedPerSec)) + " Infected per second";
      }
   }
}
