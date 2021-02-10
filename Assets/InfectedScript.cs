using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectedScript : MonoBehaviour
{
   public static double Infected;
   public static double InfectedPerTap = 1;
   public static double InfectedPerSec = 0.1;

   public Text InfectedText;
   public Text InfecdedTextShop;

   private void Update()
   {
      Infected += InfectedPerSec * Time.deltaTime;
      UpdateInfectedTexts();
   }


   public void InfectClick() 
   {
      Infected += 1;
      UpdateInfectedTexts();
   }

   private void UpdateInfectedTexts()
   {
      InfecdedTextShop.text = "infected: " + Math.Round(Infected).ToString();
      InfectedText.text = "infected: " + Math.Round(Infected).ToString();
   }
}
