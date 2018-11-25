using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelMange : MonoBehaviour {

    public float autoload;

    void Start()
    {
        Invoke("LoadNextLevel", autoload);
    }

	// Use this for initialization
	public void LoadLevel (string name) {
        
        SceneManager.LoadScene(name);
	}
	
	// Update is called once per frame
	public void SetQuite () {
        Application.Quit();
	}

    public void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }
}
