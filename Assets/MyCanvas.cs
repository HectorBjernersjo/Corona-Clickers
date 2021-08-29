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
   public Text AscensionPanelText;
   public Text AscensionRecommendationText;
   public GameObject BoostButton;
   public GameObject AscendButton;

   // Start is called before the first frame update
   void Awake()
    {
       Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
