using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public float weponDamage;
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
            if(other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weponDamage);
            }

        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shootable" || other.gameObject.tag == "Ground")
        {
            Pc.RemoveBullet();
            Instantiate(bulletExpl, transform.position, transform.rotation);
            Destroy(gameObject);
            if (other.gameObject.layer == LayerMask.NameToLayer("enemy"))
            {
                enemyHealth hurtEnemy = other.gameObject.GetComponent<enemyHealth>();
                hurtEnemy.addDamage(weponDamage);
            }
        }
    }
}
