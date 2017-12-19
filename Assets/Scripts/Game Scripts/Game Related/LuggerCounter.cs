using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuggerCounter : MonoBehaviour {

    public Luggage[] luggage;
    int luggageCount = 0;
    public Text currentLuggage;
    public Text totalLuggage;

    void Awake()
    {
        totalLuggage.text = "" + luggage.Length;
    }

    void Update()
    {
        int current = 0;

        for (int i = 0; i < luggage.Length; i++)
        {
            if (luggage[i].isInCart())
                current++;
            luggageCount = Mathf.Clamp(current, 0, luggage.Length);
            currentLuggage.text = luggageCount + "";
        }
    }

    public int getLuggageCount()
    {
        return luggageCount;
    }

    public bool isFull()
    {
        return (luggageCount >= luggage.Length);
    }
}
