using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class option : MonoBehaviour {

    public Slider Volslider;
    public levelMange levelmanger;
    private musicmanage musicmanger;

	// Use this for initialization
	void Start () {
        musicmanger = GameObject.FindObjectOfType<musicmanage>();
	}
	
	// Update is called once per frame
	void Update () {
        Volslider.value = prefmange.GetMasterVolume();
    }

    public void SaveAndExit()
    {

        prefmange.SetMasterVolume(Volslider.value);

        levelmanger.LoadLevel("Startmenu");

    }
    public void SetDefaults()
    {

        Volslider.value = 0.8f;

        

    }
}
