using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMap : MonoBehaviour
{
    public GameObject enemyGraphic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyGraphic == null)
            Destroy(gameObject);
    }
}
