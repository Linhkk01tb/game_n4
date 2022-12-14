using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void level1()
    {
        Application.LoadLevel("level1");
    }
    public void level2()
    {
        Application.LoadLevel("level2");
    }
    public void level3()
    {
        Application.LoadLevel("level3");
    }
}
