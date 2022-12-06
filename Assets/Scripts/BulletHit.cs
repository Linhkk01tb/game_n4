using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    projecttileController Pc;
    public GameObject bulletExpl;
   

    void Awake()
    {
        Pc = GetComponentInParent<projecttileController>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Shootable" || other.gameObject.tag == "Ground")
        {
            Pc.RemoveBullet();
            Instantiate(bulletExpl, transform.position, transform.rotation);
            Destroy(gameObject);

        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shootable" || other.gameObject.tag == "Ground")
        {
            Pc.RemoveBullet();
            Instantiate(bulletExpl, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
