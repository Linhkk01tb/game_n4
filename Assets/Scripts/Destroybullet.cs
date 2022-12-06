using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroybullet : MonoBehaviour
{
    public float alive;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, alive);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
