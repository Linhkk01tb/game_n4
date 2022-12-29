using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Image victory;
    public Button vic;
    public AudioClip GameOver;
    public AudioClip Victory;
    AudioSource ads;
    public GameObject nv;

    // Start is called before the first frame update
    void Start()
    {
        ads = GetComponent<AudioSource>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(nv == null)
        {
            ads.clip = GameOver;
            ads.loop = false;
            ads.Play();
        }    
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            victory.gameObject.SetActive(true);
            vic.gameObject.SetActive(true);
            Time.timeScale = 0f;
            ads.clip = Victory;
            ads.loop = false;
            ads.Play();
        }
    }
}
