using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundImageScript : MonoBehaviour
{
   public float Speed;
   public float RoatationSpeed;
   public Vector3 StartPosition = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
      Speed = 30;
      StartPosition = new Vector3(1,3,4);
      RoatationSpeed =0;
    }

   public void SetStartLocation()
   {
      transform.localPosition = new Vector3(Random.Range(-400, 400), 500, 0);
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
