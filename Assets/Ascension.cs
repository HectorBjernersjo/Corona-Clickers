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

   public static double firstPointCost  = 1000;

   public static Text PossiblePointsText;
   public static Slider AscensionSlider;
   public static Text TopPanelPossiblePointsText;
   public static Text TopPanelAscensionPointsText;
   public static GameObject AscensionShopButton;
   public static Text AscensionPanelText;

   public Text TextPrefab;
   public List<Text> TextPrefabs = new List<Text>();

   public static double IpsUpgradeMultiplier = 1;
   public static double IptUpgradeMultiplier = 1;

   void Start()
   {
      PossiblePointsText = MyCanvas.Instance.PossiblePointsText;
      AscensionSlider = MyCanvas.Instance.AscensionSlider;
      TopPanelPossiblePointsText = MyCanvas.Instance.TopPanelPossiblePointsText;
      TopPanelAscensionPointsText = MyCanvas.Instance.TopPanelAscensionPointsText;
      AscensionShopButton = MyCanvas.Instance.AscensionShopButton;
      AscensionPanelText = MyCanvas.Instance.AscensionPanelText;
   }

   public static void InfectedHasIncreased(double infected)
   {
      PossiblePoints = GetPossiblePoints();
      UpdateTexts();
      UpdateSlider();
   }

   private static double GetPossiblePoints()
   {
      var possiblePoints = Math.Floor(Math.Log10(InfectedScript.InfectedEver) * 10 - AscensionPoints - SpentPoints - Math.Log10(firstPointCost) * 10);

      if (possiblePoints >= 0)
         return possiblePoints;
      return 0;

   }

   public static double GetIpsMultiplier()
   {
      return IpsUpgradeMultiplier * BiotechResearch.BiotechResearchMultiplier;
   }

   public static double GetIptMultiplier()
   {
      return IptUpgradeMultiplier * BiotechResearch.BiotechResearchMultiplier;
   }

   private static void UpdateSlider()
   {
      double lastPointTotal;

      if (PossiblePoints + AscensionPoints >= 1)
         lastPointTotal = Math.Pow(10, (PossiblePoints + AscensionPoints + SpentPoints + Math.Log10(firstPointCost) * 10) / 10.0);
      else
         lastPointTotal = 0;

      var nextPointTotal = Math.Pow(10, (PossiblePoints + AscensionPoints + SpentPoints + Math.Log10(firstPointCost) * 10 + 1)/10.0);
      var fromLastToNextPoint = nextPointTotal - lastPointTotal;
      var percentageFilled = (InfectedScript.InfectedEver - lastPointTotal) / fromLastToNextPoint;
      AscensionSlider.value = (float)percentageFilled;
   }


   public static void UpdateTexts()
   {
      PossiblePointsText.text = PengaNamn.FormateraMedEnhet(PossiblePoints);
      //AscensionSlider.value = (float)((NeededPerPoint - LeftToNextPoint)/ NeededPerPoint);
      TopPanelPossiblePointsText.text = "Restarting would grant you " + PengaNamn.FormateraMedEnhet(PossiblePoints) + " ascension points";
      TopPanelAscensionPointsText.text = "Ascension points:" + PengaNamn.FormateraMedEnhet(AscensionPoints);
      AscensionPanelText.text = "Ascend (restart) to earn " + PossiblePoints + " ascension points. Spend these on special ascension upgrades to get a big boost on your next playthrough.";
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
   }

}
