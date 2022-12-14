using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusController : MonoBehaviour
{
    public float maxSpeed; // tốc độ di chuyển tối đa
    public float jumpHeight; // độ cao khi nhảy
    bool facingRight; // xoay mặt sang phải
    bool grounded; // check chân chạm đất
    Rigidbody2D RadiusBody;
    Animator RadiusAnimator;

    //súng đạn

    public Transform Muzzle;
    public GameObject bullet;
    float firerate = 0.5f;
    float nextfire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        RadiusBody = GetComponent<Rigidbody2D>();
        RadiusAnimator = GetComponent<Animator>();
        
        facingRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        RadiusAnimator.SetFloat("speed", Mathf.Abs(move));

        RadiusBody.velocity =new Vector2(move*maxSpeed, RadiusBody.velocity.y);

        float jump = Input.GetAxis("Jump");
        RadiusAnimator.SetFloat("height", Mathf.Abs(jump));

        if (move > 0 && !facingRight)
        {
            flip();
        }
        else if (move < 0 && facingRight)
        {
            flip();
        }

        if (Input.GetKey(KeyCode.K))
        {
            if (grounded)
            {
                RadiusBody.velocity = new Vector2(RadiusBody.velocity.x, jump * jumpHeight);
                grounded = false;
                
                
            }
        }

        if (Input.GetAxisRaw("Fire1") > 0)
        {
            firebullet();
            RadiusAnimator.SetBool("shoot", true);
        }
        else if (Input.GetAxisRaw("Fire1") <= 0)
        {
            RadiusAnimator.SetBool("shoot", false);
        }
       

    }

    void firebullet()
    {
        if(Time.time > nextfire)
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
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}
