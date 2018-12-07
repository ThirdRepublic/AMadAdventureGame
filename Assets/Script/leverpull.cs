using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverpull : MonoBehaviour {
    BoxCollider2D mycollider;
    Animator myanimator;
    public GameObject[] objectdestroyed;
    public LayerMask playerLayer;
    
    // Use this for initialization
    void Start () {
        myanimator = GetComponent<Animator>();

        mycollider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        pulllever();

    }
    private void pulllever()
    {
        
        if (mycollider.IsTouchingLayers(playerLayer))
        {
            bool isLeverpulled = Input.GetKeyDown(KeyCode.Return);
            if (isLeverpulled)
            {
                myanimator.SetBool("switch", isLeverpulled);
                
                for(int i = 0; i < objectdestroyed.Length; i++)
                {
                    try
                    {
                        Debug.Log(objectdestroyed[i].name);
                        Object.Destroy(objectdestroyed[i]);
                    }
                    catch
                    {

                    }
                 }
            }
           
            
            
            
        }
    }
}
