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
      throw new System.NotImplementedException();
   }

   public void OnUnityAdsDidError(string message)
   {
      throw new System.NotImplementedException();
   }

   public void OnUnityAdsDidStart(string placement)
   {
      throw new System.NotImplementedException();
   }

   public void OnUnityAdsDidFinish(string placement, ShowResult showResult)
   {
      
   }
}