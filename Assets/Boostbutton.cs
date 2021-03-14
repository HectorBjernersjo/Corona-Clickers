using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.PlayerLoop;

public class Boostbutton : MonoBehaviour
{
   private float counter;
   public static bool Boost;
   public Text Boosttext;
         

   public void Boostfunc()
   {
      Boost = true;
      counter = 100;
   }

   void Update()
   {
      Boosttext.gameObject.SetActive(true);
      Boosttext.text = Math.Round(counter).ToString();
      counter -= 1 * Time.deltaTime;
      if (counter <= 0)
      {
         Boost = false;
         Boosttext.gameObject.SetActive(false);
         //Emmas second achivement :D :)

      } 
   }
}
