using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShopScript : MonoBehaviour
{
    public GameObject Shop;
    public GameObject ipspanel;
    public GameObject ipcpanel;
    public void Openips(){
        ipspanel.SetActive(true);

    }

    public void Closeipspanel()
    {
        ipspanel.SetActive(false);
    }

    public void Openipcpanel()
    {
        ipcpanel.SetActive(true);
    }

    public void Closeipcpanel()
    {
        ipcpanel.SetActive(false);
    }


        public void OpenShop() {
      Shop.SetActive(true);
   }

   public void CloseShop() {
      Shop.SetActive(false);
   }
}
