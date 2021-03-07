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

   CoronaAnimator coronaAnimator;

   private void Start()
   {
      coronaAnimator = GetComponentInChildren<CoronaAnimator>();
   }

   private void Update()
   {
      //Infecta varje sekund
      Infected += InfectedPerSec * Time.deltaTime;
      UpdateInfectedTexts();

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
   }
}
