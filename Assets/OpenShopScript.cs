using UnityEngine;

public class OpenShopScript : MonoBehaviour
{
   public GameObject Shop;
   public GameObject IpsPanel;
   public GameObject IptPanel;
   public GameObject AscensionUpgradesPanel;
   public GameObject AscensionTopPanel;
   public GameObject NormalTopPanel;

   public void OpenShop()
   {
      Shop.SetActive(true);
      foreach (var building in BuildingHandler.BuildingList)
      {
         building.UpdateTexts();
      }
   }

   public void CloseShop()
   {
      Shop.SetActive(false);
      IptPanel.SetActive(false);
      IpsPanel.SetActive(false);
      AscensionUpgradesPanel.SetActive(false);
      AscensionTopPanel.SetActive(false);
      NormalTopPanel.SetActive(true);
      //OMG!!! Epic
   }
}
