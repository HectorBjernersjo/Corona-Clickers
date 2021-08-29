using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;

public class Boost : MonoBehaviour
{
   public static float BoostSecondsLeft;
   public Text BoostText;
   public Slider BoostSlider;
   public static Boost Instance;
   public GameObject BoostPanel;
   public Text BoostInfoText;
   public GameObject SkippedPanel;

   void Start()
   {
      Instance = this;
   }


   public void ShowBoostPanel()
   {
      if(BoostSecondsLeft <= 0)
         BoostPanel.SetActive(true);

      if (BoostUpgrade.BoostEarningMultiplier < 3 && BoostUpgrade.BoostTimeMultiplier < 2)
         BoostInfoText.text = "Watch an ad to double your ips (infected per second) for 2 hours";
      else
         BoostInfoText.text = "Watch an ad to multiply your ips by " + Math.Round(BoostUpgrade.BoostEarningMultiplier) +
                              " for " + Math.Round(BoostUpgrade.BoostTimeMultiplier, 1) + " hours";

   }

   public void BoostFunction()
   {
      Ads.ShowBonusVid();
   }

   void Update()
   {
      if (BoostSecondsLeft <= 0)
      {
         BoostSlider.gameObject.SetActive(false);
         BoostSecondsLeft = 0;
         //Emmas second achivement :D :)
      }
      else
      {
         BoostSecondsLeft -= Time.deltaTime;

         TimeSpan timeLeft = TimeSpan.FromSeconds(Math.Round(BoostSecondsLeft));

         BoostText.text = timeLeft.ToString();
         BoostSlider.value = (float) (BoostSecondsLeft / (3600 * BoostUpgrade.BoostTimeMultiplier));
      }
   }
}
