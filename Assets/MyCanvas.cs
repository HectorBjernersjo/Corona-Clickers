using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyCanvas : MonoBehaviour
{
   public static MyCanvas Instance;

   public Text TapMultiplierText;
   public Text PossiblePointsText;
   public Slider AscensionSlider;
   public Text TopPanelPossiblePointsText;
   public Text TopPanelAscensionPointsText;
   public GameObject AscensionShopButton;


   // Start is called before the first frame update
   void Start()
    {
       Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
