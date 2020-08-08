using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject shop;

    public void OpenShop()
    {
        //shop.SetActive(true);
        print("opening shop");
    }

    public void CloseShop()
    {
        //shop.SetActive(false);
        print("closing shop");
    }







    public void BuyBigBullets()
    {
        playerController.boughtBigBullet = true ;
    }
}
