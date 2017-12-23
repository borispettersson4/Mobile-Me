using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSound : MonoBehaviour {

    public Sprite a;
    public AudioClip aSound;
    public Sprite b;
    public AudioClip bSound;
    public Image imageSource;

	void Awake () {
		if(imageSource.sprite == a)
        {
            GetComponent<AudioSource>().clip = aSound;
            GetComponent<AudioSource>().Play();
        }
        else if (imageSource.sprite == b)
        {
            GetComponent<AudioSource>().clip = bSound;
            GetComponent<AudioSource>().Play();
        }

	}
}
