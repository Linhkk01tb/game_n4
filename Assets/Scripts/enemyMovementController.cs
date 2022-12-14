using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementController : MonoBehaviour
{
    public float speed;
    Rigidbody2D enemyRB;
    Animator enemyAni;
    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;

    void Awake()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAni = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFlip)
        {
            nextFlip = Time.time + facingTime;
            Flip();
        }
    }
    void Flip()
    {
        if (!canFlip) return;
        facingRight = !facingRight;
        Vector3 theScale = enemyGraphic.transform.localScale;
        theScale.x *= -1;
        enemyGraphic.transform.localScale = theScale;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (facingRight && other.transform.position.x < transform.position.x)
            {
                Flip();
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                Flip();
            }
            canFlip = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (!facingRight)
            {
                enemyRB.AddForce(new Vector2(-1, 0) * speed);
            }else if (facingRight)
            {
                enemyRB.AddForce(new Vector2(1, 0) * speed);
            }
            enemyAni.SetBool("run", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            enemyRB.velocity = new Vector2(0, 0);
            enemyAni.SetBool("run", false);
        }
    }
}
