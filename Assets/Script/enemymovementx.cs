using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovementx : MonoBehaviour {

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
        if (Isfacingforward())
        {
            myRigidbody.velocity = new Vector2(movespeed, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector2(-movespeed, 0f);
        }
    }
    bool Isfacingforward()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2( -(Mathf.Sign(myRigidbody.velocity.x)), 1f);
    }
}
