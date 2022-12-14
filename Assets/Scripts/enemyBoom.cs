using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBoom : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    public float pushBackForce;
    Animator enemyAni;
    public GameObject bang;

    // Start is called before the first frame update
    void Start()
    {
        
        enemyAni = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            RadiusHealth thePlayerHealth = other.gameObject.GetComponent<RadiusHealth>();
            thePlayerHealth.addDamage(damage);
            pushBack(other.transform);
            Instantiate(bang, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void pushBack(Transform pushedObject)
    {
        Vector2 pushDirection = new Vector2((pushedObject.position.x - transform.position.x), 0.1f).normalized;
        pushDirection *= pushBackForce;
        Rigidbody2D pushRB = pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity = Vector2.zero;
        pushRB.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
