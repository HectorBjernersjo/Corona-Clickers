using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapCombo : MonoBehaviour
{
   public static float TapMultiplier = 1;
   internal static float IncreasePerTap = 0.03f;
   private static float fadeOutCounter;
   private static float fadeOutCounterMax = 2;
   public static bool IsActive;

   public static Text MultiplierText => MyCanvas.Instance.TapMultiplierText;

   void Update()
   {
      if (!IsActive) return;

      if (fadeOutCounter <= 0)
      {
         TapMultiplier = 1;
         MultiplierText.gameObject.SetActive(false);
      }
      else
      {
         fadeOutCounter -= Time.deltaTime * 3;
         MultiplierText.color = new Color(1, 1, 1, fadeOutCounter/fadeOutCounterMax);

         var currentScale = MultiplierText.transform.localScale;
         var sizeDecrease = Time.deltaTime;
         var minSize = 0;

         if(currentScale.x >= minSize)
            MultiplierText.transform.localScale = new Vector3(currentScale.x - sizeDecrease, currentScale.y - sizeDecrease, currentScale.z);
      }
   }

   public static void ToDoWhenClick()
   {
      TapMultiplier +=  IncreasePerTap;

      MultiplierText.text = "x" + Math.Round(TapMultiplier, 2);
      fadeOutCounter = fadeOutCounterMax;

      MultiplierText.gameObject.SetActive(true);

      var newColor = MultiplierText.color;
      newColor.a = 1;
      MultiplierText.color = Color.white;

      if(TapMultiplier >= 1.5)
         MultiplierText.transform.localScale = new Vector3(1.1f, 1.1f, 1);

      else if(TapMultiplier >= 2)
         MultiplierText.transform.localScale = new Vector3(1.2f, 1.2f, 1);

      else if (TapMultiplier >= 5)
         MultiplierText.transform.localScale = new Vector3(1.3f, 1.3f, 1);
      else
         MultiplierText.transform.localScale = new Vector3(1,1,1);
   }
}
