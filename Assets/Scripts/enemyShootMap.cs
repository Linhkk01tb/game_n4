using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShootMap : MonoBehaviour
{
    Rigidbody2D enemyRB;
    Animator enemyAni;
    public GameObject enemyGraphic;
    bool facingRight = true;
    float facingTime = 5f;
    float nextFlip = 0f;
    bool canFlip = true;

    public Transform Muzzle;
    public GameObject bullet;
    float firerate = 0.5f;
    float nextfire = 0f;

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
                firebullet();
                enemyAni.SetBool("shoot", true);
            }
            else if (!facingRight && other.transform.position.x > transform.position.x)
            {
                Flip();
                firebullet();
                enemyAni.SetBool("shoot", true);
            }
            canFlip = false;
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            firebullet();
            enemyAni.SetBool("shoot", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canFlip = true;
            enemyAni.SetBool("shoot", false);
        }
    }
    void firebullet()
    {
        if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;
            if (facingRight)
            {
                Instantiate(bullet, Muzzle.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (!facingRight)
            {
                Instantiate(bullet, Muzzle.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
}
