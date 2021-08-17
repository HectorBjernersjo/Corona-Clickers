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

   void Start()
   {
      Instance = this;
   }
         

   public void BoostFunction()
   {
      Ads.ShowBonusVid();
      BoostSecondsLeft = 3600;
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
         BoostSlider.value = BoostSecondsLeft / 3600;
      }
   }
}
