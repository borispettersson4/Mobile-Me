using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.ObjectModel;

public class Toll : MonoBehaviour {

    public Animator animator;
    public TokenCounter tokenCounter;
    public GameObject guiComponent;
    public string animationA;
    public string animationB;
    public Player player;
    public int tokenCount;

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player.gameObject)
        {
                guiComponent.SetActive(true);  
                if(player.GetComponent<Rigidbody>().velocity.magnitude != 0)
                {
                    player.GetComponent<Rigidbody>().velocity.Normalize();
                    player.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                }           
        }
    }

    public void accept()
    {
        if (tokenCounter.getTokenCount() >= tokenCount)
        {
            tokenCounter.substractTokens(tokenCount);
            guiComponent.SetActive(false);
            animator.Play(animationA);
        }
    }

    public void deny()
    {
        guiComponent.SetActive(false);
        animator.Play(animationB);
    }
}
