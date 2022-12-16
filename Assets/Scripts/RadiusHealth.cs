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
    public Image lose;
    public Button lose_btn;
    Rigidbody2D nhanvat;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        nhanvat = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(nhanvat.velocity.y <= -10f)
        {
            Dead();
            lose.gameObject.SetActive(true);
            lose_btn.gameObject.SetActive(true);
        }

    }
    public void addDamage(float dame)
    {
        if (dame <= 0) return;
        currentHealth -= dame;
        healthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            Dead();
            lose.gameObject.SetActive(true);
            lose_btn.gameObject.SetActive(true);
        }
    }
    void Dead()
    {
        Instantiate(bang, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
