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

   void Start()
   {
      Instance = this;
   }


   public void ShowBoostPanel()
   {
      if(BoostSecondsLeft <= 0)
         BoostPanel.SetActive(true);
   }

   public void BoostFunction()
   {
      Ads.ShowBonusVid();
      BoostSecondsLeft = (float) (3600 * BoostUpgrade.BoostTimeMultiplier);
      BoostSlider.gameObject.SetActive(true);
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
