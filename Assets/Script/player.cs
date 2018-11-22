using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour {
    [SerializeField] float moveSpeed = 0.5f;
    // Use this for initialization
    BoxCollider2D mycollider;
    Rigidbody2D myRigidbody2D;
    CapsuleCollider2D mybodycol;
    Animator myanime;
    public LayerMask enemyLayer;
    public LayerMask pitLayer;
    public int bullets;
    public GameObject[] numofbullets;


    bool isActive = true;

    void Start () {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myanime = GetComponent<Animator>();
        mybodycol = GetComponent<CapsuleCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isActive){ return; }
        PlayerMove();
        Die();
    }

    private void Die()
    {
        if (mybodycol.IsTouchingLayers(enemyLayer))
        {

            isActive = false;
            Debug.Log("dead");
            // for(int i = 0; i < numofbullets.Length; i++) {
            //bullets--;
            // if(numofbullets.Length >= 0){
           // Debug.Log(bullets);
            //Object.Destroy(numofbullets[bullets--]);

            // }else if (numofbullets.Length <= 0)
            // {
            // Debug.Log("dead");
            //SceneManager.LoadScene("losemenu");
            //}
            //}

            //}
        }
    }
    private void PlayerMove()
    {
        var newXPos = 0f;
        var newYPos = 0f;
        // button click 
        if (CrossPlatformInputManager.GetAxis("Horizontal") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0) {
            newXPos = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
            newYPos = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed;
        }
        else // keyboard
        {
            newXPos = Input.GetAxis("Horizontal") * moveSpeed;
            newYPos = Input.GetAxis("Vertical") * moveSpeed;
        }

        Vector2 playermoveset = new Vector2(newXPos, newYPos);
        myRigidbody2D.velocity = playermoveset;
        
        myanime.SetFloat("horizontal", newXPos);
        myanime.SetFloat("vertical", newYPos);

     


    }
   
}
