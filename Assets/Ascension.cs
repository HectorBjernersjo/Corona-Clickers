using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Ascension : MonoBehaviour
{
   public static bool HasAscendedBefore;

   public static double AscensionPoints;
   public static double PossiblePoints;
   public static double SpentPoints;

   public static double FirstPointCost  = 1000000;

   public static Text PossiblePointsText;
   public static Slider AscensionSlider;
   public static Text TopPanelPossiblePointsText;
   public static Text TopPanelAscensionPointsText;
   public static GameObject AscensionShopButton;
   public static Text AscensionPanelText;

   public Text TextPrefab;
   public List<Text> TextPrefabs = new List<Text>();


   void Start()
   {
      PossiblePointsText = MyCanvas.Instance.PossiblePointsText;
      AscensionSlider = MyCanvas.Instance.AscensionSlider;
      TopPanelPossiblePointsText = MyCanvas.Instance.TopPanelPossiblePointsText;
      TopPanelAscensionPointsText = MyCanvas.Instance.TopPanelAscensionPointsText;
      AscensionShopButton = MyCanvas.Instance.AscensionShopButton;
      AscensionPanelText = MyCanvas.Instance.AscensionPanelText;

      if(!HasAscendedBefore)
         MyCanvas.Instance.AscensionRecommendationText.gameObject.SetActive(true);
   }

   public static void InfectedHasIncreased(double infected)
   {
      PossiblePoints = GetPossiblePoints();
      UpdateTexts();
      UpdateSlider();
   }

   public static double GetPossiblePoints()
   {
      var possiblePoints = Math.Floor(Math.Log10(InfectedScript.InfectedEver) * 10 - AscensionPoints - SpentPoints - Math.Log10(FirstPointCost) * 10);

      if (possiblePoints >= 0)
      {
         return possiblePoints;
      }

      return 0;

   }

   public static double GetIpsMultiplier()
   {
      return ResistentBacteria.IPSMultiplier * BiotechResearch.BiotechResearchMultiplier;
   }

   public static double GetIptMultiplier()
   {
      return BiotechResearch.BiotechResearchMultiplier;
   }

   private static void UpdateSlider()
   {
      double lastPointTotal;

      if (PossiblePoints + AscensionPoints + SpentPoints >= 1)
         lastPointTotal = Math.Pow(10, (PossiblePoints + AscensionPoints + SpentPoints + Math.Log10(FirstPointCost) * 10) / 10.0);
      else
         lastPointTotal = 0;

      var nextPointTotal = Math.Pow(10, (PossiblePoints + AscensionPoints + SpentPoints + Math.Log10(FirstPointCost) * 10 + 1)/10.0);
      var fromLastToNextPoint = nextPointTotal - lastPointTotal;
      var percentageFilled = (InfectedScript.InfectedEver - lastPointTotal) / fromLastToNextPoint;
      MyCanvas.Instance.AscensionSlider.value = (float)percentageFilled;
   }


   public static void UpdateTexts()
   {
      MyCanvas.Instance.PossiblePointsText.text = PengaNamn.FormateraMedEnhet(PossiblePoints);
      MyCanvas.Instance.TopPanelPossiblePointsText.text = "Restarting would grant you " + PengaNamn.FormateraMedEnhet(PossiblePoints) + " ascension points";
      MyCanvas.Instance.TopPanelAscensionPointsText.text = "Ascension points: " + PengaNamn.FormateraMedEnhet(AscensionPoints);
      MyCanvas.Instance.AscensionPanelText.text = "Ascend (restart) to earn " + PossiblePoints + " ascension points. Spend these on special ascension upgrades to get a big boost on your next playthrough.";
   }

   public static void Ascend()
   {
      AscendRestart();

      AscensionPoints += PossiblePoints;
      PossiblePoints = 0;

      if(!HasAscendedBefore)
         AscensionShopButton.SetActive(true);

      UpdateTexts();
   }

   public static void AscendRestart()
   {
      InfectedScript.Infected = 0;
      BuildingHandler.ResetBuildings();
   }

   public void ClickToSeePossiblePointsInfo()
   {
      var text = Instantiate(TextPrefab, new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0), Quaternion.identity);
      text.text = "Ascend to gain " + PossiblePoints + " ascension points";
      text.transform.SetParent(AscensionSlider.transform);
      TextPrefabs.Add(text);
   }

   void Update()
   {
      foreach (var text in TextPrefabs)
      {
         text.color = new Color(1,1,1, text.color.a - Time.deltaTime/3);
         text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y + Time.deltaTime * 100, 0);
         if (text.color.a == 0)
            Destroy(text);
      }

      if(PossiblePoints + AscensionPoints + SpentPoints > 0)
         MyCanvas.Instance.AscendButton.SetActive(true);
      else
         MyCanvas.Instance.AscendButton.SetActive(false);

   }

}
