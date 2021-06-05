using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class Ads : MonoBehaviour
{
   string GooglePlay_ID = "4157017";
   bool testMode = true;
   // Start is called before the first frame update
   void Start()
   {
      Advertisement.Initialize(GooglePlay_ID, testMode);
   }

   public static void ShowAD()
   {
      Advertisement.Show();
   }

   // Update is called once per frame
   void Update()
   {

   }
}