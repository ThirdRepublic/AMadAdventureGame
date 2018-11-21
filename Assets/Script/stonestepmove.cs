using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stonestepmove : MonoBehaviour {
    public float movespeed = 1f;
    Rigidbody2D myRigidbody;
    public GameObject player;
    public string platmove;
    
    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (platmove == "Vertical")
        {
            myRigidbody.velocity = new Vector2(0f, movespeed);
        }else if (platmove == "Horizontal") {
            myRigidbody.velocity = new Vector2(movespeed, 0f);
        }
       
	}

  

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        movespeed *= -1;
    }
}