using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicmanage : MonoBehaviour {

    public AudioClip[] MusicArray;
    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("Welcome to " + name);
    }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void levelloaded (int level) {
        AudioClip thislevelMusic = MusicArray[level];
        Debug.Log("play: " + thislevelMusic);
        if (thislevelMusic)
        {
            audioSource.clip = thislevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }

    }
}
