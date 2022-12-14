using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public Transform Muzzle;
    bool facingRight;
    public GameObject bullet;
    float firerate = 0.5f;
    float nextfire = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
