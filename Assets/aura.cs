using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aura : MonoBehaviour
{
   public RawImage aura1;
   public RawImage aura2;

   // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
       aura1.transform.Rotate(0,0,Time.deltaTime * 3);
       aura2.transform.Rotate(0, 0, -Time.deltaTime * 3);
   }
}
