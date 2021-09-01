using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class Ads : MonoBehaviour, IUnityAdsListener
{
   string GooglePlay_ID = "4157017";
   bool testMode = true;

   private static string placement = "Rewarded_Android";
   // Start is called before the first frame update
   void Start()
   {
      Advertisement.Initialize(GooglePlay_ID, testMode);
   }

   public static void ShowBonusVid()
   {
         Advertisement.Show(placement);
   }
   

   // Update is called once per frame
   void Update()
   {

   }

   public void OnUnityAdsReady(string placement)
   {
      
   }

   public void OnUnityAdsDidError(string message)
   {
      Debug.Log(message);
   }

   public void OnUnityAdsDidStart(string placement)
   {
      
   }

   public void OnUnityAdsDidFinish(string placement, ShowResult showResult)
   {
      //if (showResult == ShowResult.Finished)
      //{
      //   Boost.BoostSecondsLeft = (float)(3600 * BoostTimeUpgrade.BoostTimeMultiplier);
      //   Boost.Instance.BoostSlider.gameObject.SetActive(true);
      //}
      //else if (showResult == ShowResult.Skipped)
      //{
      //   Boost.Instance.SkippedPanel.SetActive(true);
      //}
      //else if (showResult == ShowResult.Failed)
      //{
      //   Debug.Log("epic ad fail");
      //}
   }
}