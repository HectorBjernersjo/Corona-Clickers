using UnityEngine;

public class OpenShopScript : MonoBehaviour
{
   public GameObject Shop;
   public GameObject IpsPanel;
   public GameObject IptPanel;

   public void OpenShop()
   {
      Shop.SetActive(true);
   }

   public void CloseShop()
   {
      Shop.SetActive(false);
      IptPanel.SetActive(false);
      IpsPanel.SetActive(false);
      //OMG!!! Epic
   }
}
