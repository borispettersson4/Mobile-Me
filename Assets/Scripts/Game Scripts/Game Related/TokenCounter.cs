using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TokenCounter : MonoBehaviour
{

    int tokenCount = 0;
    public int totalTokenCount = 0;
    public Text currentTokens;
    public Text totalTokens;

    void Awake()
    {
        totalTokens.text = totalTokenCount + "";
    }

    void Update()
    {
        currentTokens.text = tokenCount + "";
    }

    public int getTokenCount()
    {
        return tokenCount;
    }

    public void addTokens(int i)
    {
        tokenCount += i;
    }

    public bool isFull()
    {
        return (tokenCount >= totalTokenCount);
    }
}
