using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour {
    public float movespeed = 1f;
    Rigidbody2D myRigidbody;

    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidbody.velocity = new Vector2(0f, movespeed);
    }
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        movespeed *= -1;
    }
}
