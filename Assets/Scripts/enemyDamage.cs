using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float damage;
    float dameRate = 0.5f;
    public float pushBackForce;
    float nextDamage;
    Animator enemyAni;
   
    // Start is called before the first frame update
    void Start()
    {
        nextDamage = 0f;
        enemyAni = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && nextDamage < Time.time)
        {
            
            RadiusHealth thePlayerHealth = other.gameObject.GetComponent<RadiusHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = dameRate + Time.time;
            pushBack(other.transform);
            
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && nextDamage < Time.time)
        {

            RadiusHealth thePlayerHealth = other.gameObject.GetComponent<RadiusHealth>();
            thePlayerHealth.addDamage(damage);
            nextDamage = dameRate + Time.time;
            pushBack(other.transform);
            enemyAni.SetBool("attack", true);

        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        enemyAni.SetBool("attack", false);
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
