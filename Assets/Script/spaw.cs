using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class Spaw : MonoBehaviour
{
    Vector3 miejsceRespawnu;
    private GameObject respawnPlace;
    private int scena;
    private Animator animacja;
    //float timer = 0.0f;
    //bool zranienie=false;
    //bool uderzenie = false;

    void Awake()
    {
        
           if(PlayerPrefs.GetFloat("PozX")!=0 && PlayerPrefs.GetFloat("PozY") != 0 && PlayerPrefs.GetFloat("PozZ") != 0)
                {
                    float PX = PlayerPrefs.GetFloat("PozX");
                    miejsceRespawnu = new Vector3(PlayerPrefs.GetFloat("PozX"), PlayerPrefs.GetFloat("PozY"), PlayerPrefs.GetFloat("PozZ"));
                    this.transform.position = miejsceRespawnu;  
                }
                else {
        respawnPlace = GameObject.FindGameObjectWithTag("Respawn");
            miejsceRespawnu = respawnPlace.transform.position;
            this.transform.position = miejsceRespawnu;
        }
    }
   /* private void Start()
    {
        animacja = GetComponent<Animator>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (uderzenie == true)
        {
            if (timer > 1.2f)
            {
                transform.position = miejsceRespawnu;
                zranienie = false;
                uderzenie = false;
            }
       
        animacja.SetBool("Zranienie", zranienie);
            }
    }*/

    private void OnCollisionEnter2D(Collision2D Player)
    {
        if (Player.gameObject.tag == "Enemy")
        {/*
            timer = 0.0f;
            zranienie = true;
            uderzenie = true;
            */
            transform.position = miejsceRespawnu;
        }
    }


    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.tag=="Fall")
        {   
                transform.position = miejsceRespawnu;
        }
     
        if (Player.tag == "Checkpoint")
        {
            miejsceRespawnu = Player.transform.position;
            
                scena = SceneManager.GetActiveScene().buildIndex;
            PlayerPrefs.SetInt("ZapisanaPlansza", scena);
            PlayerPrefs.SetFloat("PolX", Player.transform.position.x);
            PlayerPrefs.SetFloat("PolY", Player.transform.position.y);
            PlayerPrefs.SetFloat("PolZ", Player.transform.position.z);
            PlayerPrefs.Save();

        }
        if (Player.tag == "Trap")
        {
            /*
            timer = 0.0f;
            zranienie = true;
            uderzenie = false;*/
            transform.position = miejsceRespawnu;
        }
    }
}