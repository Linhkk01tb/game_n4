using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDead : MonoBehaviour
{
    Rigidbody2D nhanvat;
    // Start is called before the first frame update
    void Awake()
    {
        nhanvat = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nhanvat.velocity.y <= -20f)
        {
            Dead();
            Application.LoadLevel("MenuGame");
        }    
            
    }

    void Dead()
    {
        
            Destroy(gameObject);
    }
}
