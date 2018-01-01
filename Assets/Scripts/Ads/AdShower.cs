using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdShower : MonoBehaviour
{

    InterstitialAd interstitial;

    public bool showOnAwake = false;

    void Awake()
    {
        RequestInterstitial();
        if (showOnAwake)
        {
            showAd();
        }
    }


    private void RequestInterstitial()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8891091036612180/8457323180";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Initialize an InterstitialAd.
        InterstitialAd interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);

    }

    public void showAd()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }

    public void cleanAd()
    {
        interstitial.Destroy();
    }
}
