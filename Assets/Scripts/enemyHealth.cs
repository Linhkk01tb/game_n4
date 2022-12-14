using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class enemyHealth : MonoBehaviour
{
    
    public float maxHealth;
    float currentHealth;
    public GameObject bang;
    public Slider enemyHealthSlider;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        enemyHealthSlider.maxValue = maxHealth;
        enemyHealthSlider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamage(float dame)
    {
        enemyHealthSlider.gameObject.SetActive(true);
        currentHealth -= dame;
        enemyHealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Dead();
        }
    }
    
    void Dead()
    {
        Instantiate(bang, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
