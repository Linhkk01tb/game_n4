using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projecttileController : MonoBehaviour
{
    public float speed;
    Rigidbody2D bulletBody;
    void Awake()
    {
        bulletBody = GetComponent<Rigidbody2D>();
        if (transform.localRotation.z > 0)
        {
            bulletBody.AddForce(new Vector2(-1, 0) * speed,ForceMode2D.Impulse);
        }
        else
        {
            bulletBody.AddForce(new Vector2(1, 0) * speed, ForceMode2D.Impulse);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //chuc nang lam dan dung lai
    public void RemoveBullet()
    {
        bulletBody.velocity = new Vector2(0, 0);
    }
}
