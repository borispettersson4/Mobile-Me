using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenCounter : MonoBehaviour
{

    int tokenCount = 0;
    public int totalTokenCount = 0;
    public Text currentTokens;
    int totalTokens;

    void Awake()
    {
        totalTokens = totalTokenCount;
    }

   // void Update()
  //  {
    //    currentTokens.text = tokenCount + " / " + totalTokenCount;
   // }

    public int getTokenCount()
    {
        return tokenCount;
    }

    public void addTokens(int i)
    {
        tokenCount += i;
        currentTokens.text = tokenCount + " / " + totalTokenCount;
    }

    public void substractTokens(int i)
    {
        tokenCount -= i;
        currentTokens.text = tokenCount + " / " + totalTokenCount;
    }

    public bool isFull()
    {
        return (tokenCount >= totalTokenCount);
    }
}
