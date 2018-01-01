using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSelection : MonoBehaviour {

    bool hasShopped;
    int initialCarData = 0;
    int initialSuitData = 0;

    int tokenSet = 0;
    bool canBuy = false;

    public void setCar(int x)
    {
        PlayerPrefs.SetInt("CarData",x);
    }

    public void buyCar(int x)
    {
        if (canBuy)
            PlayerPrefs.SetInt("CarDataShop" + PlayerPrefs.GetInt("CarData"), 1);
        canBuy = false;
    }

    public void setSuit(int x)
    {
        PlayerPrefs.SetInt("SuitData", x);
    }

    public void buySuit(int x)
    {
        if(canBuy)
            PlayerPrefs.SetInt("SuitDataShop" + PlayerPrefs.GetInt("SuitData"), 1);
        canBuy = false;
    }

    public void getInitialData()
    {
        initialCarData = PlayerPrefs.GetInt("CarData");
        initialSuitData = PlayerPrefs.GetInt("SuitData");
    }

    public void setTokens(int i)
    {
        if (PlayerPrefs.GetInt("TotalTokens") >= i)
        {
            canBuy = true;
        }
    }

    public void deductTokens(int i)
    {
        if(canBuy)
        PlayerPrefs.SetInt("TotalTokens", PlayerPrefs.GetInt("TotalTokens") - i);
    }

    public void exitCar()
    {
        if (PlayerPrefs.GetInt("CarData") != 0 && PlayerPrefs.GetInt("CarDataShop" + PlayerPrefs.GetInt("CarData")) == 1)
        {

        }
        else
        {
            PlayerPrefs.SetInt("CarData", initialCarData);
        }
    }

    public void exitSuit()
    {
        if (PlayerPrefs.GetInt("SuitData") != 0 && PlayerPrefs.GetInt("SuitDataShop" + PlayerPrefs.GetInt("SuitData")) == 1)
        {

        }
        else
        {
            PlayerPrefs.SetInt("SuitData", initialSuitData);
        }
    }

}
