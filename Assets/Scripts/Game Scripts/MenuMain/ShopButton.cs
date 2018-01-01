using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour {

    public int data;
    public string type;
    public Button buttonBuy;
    public Button buttonUse;

void Update()
    {
        if(PlayerPrefs.GetInt(type + "DataShop" + data) == 1)
        {
            buttonBuy.gameObject.SetActive(false);
            buttonUse.gameObject.SetActive(true);
        }
        else
        {
            buttonBuy.gameObject.SetActive(true);
            buttonUse.gameObject.SetActive(false);
        }
    }
}
