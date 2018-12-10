using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1.5f;
    // Use this for initialization
    BoxCollider2D mycollider;
    Rigidbody2D myRigidbody2D;
    CapsuleCollider2D mybodycol;
    CircleCollider2D playerPitCol;
    Animator myanime;
    public LayerMask enemyLayer;
    public LayerMask pitLayer;
    public LayerMask stoneLayer;
    public int bullets;
    public GameObject bulletCounter;
    public GameObject bulletTile;
    public GameObject bulletMult;
    public Vector2 pushback = new Vector2(.5f, .5f);

    bool isActive = true;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myanime = GetComponent<Animator>();
        mybodycol = GetComponent<CapsuleCollider2D>();
        playerPitCol = GetComponent<CircleCollider2D>();
        bulletCounter = GameObject.Find("bullet_count");
        bulletTile = GameObject.Find("bullet1");
        bulletMult = GameObject.Find("bullet_mult");
        bullets = 3; //set the default bullet count
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) { return; }
        UpdateBulletCounter();
        PlayerMove();
        Die();
        push();
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        GameObject gameObj = c.gameObject;
        if (gameObj.layer == 10 && gameObj.activeSelf)
        {
            gameObj.SetActive(false);
            //layer 10 is enemy layer
            if (bullets > 0)
            {
                Debug.Log(bullets);
                bullets--;
            }
            else
            {
                isActive = false;
                Debug.Log("dead");
                SceneManager.LoadScene("losemenu");
            }
        }
    }

    private void Die()
    {
        if (playerPitCol.IsTouchingLayers(pitLayer))
        {
            Debug.Log("pit");
            isActive = false;
            SceneManager.LoadScene("losemenu");
        }
    }

    private void push()
    {
        if (mybodycol.IsTouchingLayers(stoneLayer))
        {
            GetComponent<Rigidbody2D>().velocity = pushback;
        }
    }

    private void PlayerMove()
    {
        var newXPos = 0f;
        var newYPos = 0f;
        // button click 
        if (CrossPlatformInputManager.GetAxis("Horizontal") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0)
        {
            //Debug.Log(bullets);
            newXPos = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed * 0.7f;
            newYPos = CrossPlatformInputManager.GetAxis("Vertical") * moveSpeed * 0.7f;
        }
        else // keyboard
        {
            newXPos = Input.GetAxis("Horizontal") * moveSpeed * 0.3f;
            newYPos = Input.GetAxis("Vertical") * moveSpeed * 0.3f;
        }
        Vector2 playermoveset = new Vector2(newXPos, newYPos);
        myRigidbody2D.velocity = playermoveset;

        myanime.SetFloat("horizontal", newXPos);
        myanime.SetFloat("vertical", newYPos);




    }

    private void UpdateBulletCounter()
    {
        if (bullets <= 0)
        {
            bulletCounter.SetActive(false);
            bulletTile.SetActive(false);
            bulletMult.SetActive(false);
            return;
        }
        bulletCounter.SetActive(true);
        bulletTile.SetActive(true);
        bulletMult.SetActive(true);
        bulletCounter.GetComponent<UnityEngine.UI.Text>().text = bullets.ToString();
    }

}
