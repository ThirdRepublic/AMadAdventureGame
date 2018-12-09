using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class leverpull : MonoBehaviour
{
    BoxCollider2D mycollider;
    Animator myanimator;
    public GameObject[] objectdestroyed;
    public LayerMask playerLayer;

    // Use this for initialization
    void Start()
    {
        myanimator = GetComponent<Animator>();
        mycollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        pulllever();

    }
    private void pulllever()
    {

        if (mycollider.IsTouchingLayers(playerLayer))
        {
            //bool isLeverpulled = Input.GetKeyDown(KeyCode.Return);
            //if (isLeverpulled)
            //{
            myanimator.SetBool("switch", true);

            for (int i = 0; i < objectdestroyed.Length; i++)
            {
                StartCoroutine(destroyAfter1Sec(objectdestroyed[i]));
                Debug.Log(objectdestroyed[i].name);

            }
            // }




        }
    }
    IEnumerator destroyAfter1Sec(GameObject obj)
    {
        yield return new WaitForSecondsRealtime(1);
        UnityEngine.Object.Destroy(obj);
    }
}
