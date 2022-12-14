using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadiusHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;
    public GameObject bang;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamage(float dame)
    {
        if (dame <= 0) return;
        currentHealth -= dame;
        healthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            Dead();
            Application.LoadLevel("MenuGame");
        }
    }
    void Dead()
    {
        Instantiate(bang, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
