using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingHandler : MonoBehaviour
{
   public static List<Building> BuildingList = new List<Building>();
   void Start()
    {
      foreach (var building in GetComponentsInChildren<Building>(includeInactive: true))
      {
         BuildingList.Add(building);
      }
    }

   public static void ResetBuildings()
   {
      foreach (var building in BuildingList)
      {
         building.CurrentCost = building.StartCost;
         building.NrBought = 0;
         building.UpdateTexts();
      }
   }

}
