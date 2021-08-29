using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundAnimatorScript : MonoBehaviour
{
   public RawImage BackgroundCorona;
    public RawImage GoldCorona;
    List<RawImage> BackgroundCoronaList = new List<RawImage>();
   float counter;
    float spawnSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      counter += Time.deltaTime;

      if (counter >= 1/spawnSpeed)
      {
         RawImage currentCoronaImage;
            if (Boost.BoostSecondsLeft > 0)
               currentCoronaImage = Instantiate(GoldCorona);
            else
                currentCoronaImage = Instantiate(BackgroundCorona);

            currentCoronaImage.transform.SetParent(this.transform);
            currentCoronaImage.GetComponent<BackgroundImageScript>().SetStartLocation();

            currentCoronaImage.transform.localScale = new Vector3(ScreenSize.SomePercentageOfTheScreen, ScreenSize.SomePercentageOfTheScreen, 1);

            BackgroundCoronaList.Add(currentCoronaImage);
            counter = 0;
      }

      foreach (RawImage coronaImage in BackgroundCoronaList.ToArray())
      {
         var transform = coronaImage.transform.localPosition;
         var backGroundImageScript = coronaImage.GetComponent<BackgroundImageScript>();
         coronaImage.transform.localPosition = new Vector3(transform.x, transform.y -  backGroundImageScript.Speed * Time.deltaTime, transform.z);
         coronaImage.transform.Rotate(-Vector3.forward * Time.deltaTime * backGroundImageScript.RoatationSpeed);

         if (transform.y <= -500)
         {
            BackgroundCoronaList.Remove(coronaImage);
            Destroy(coronaImage);
         }
      }
    }
}
