using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextlevel : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("winmenu");
    }
}
