﻿using System.Collections;
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
    float timer = 0.0f;
    public int zranienie = 0;
    public int uderzenie = 0;

    public GameObject part;
    static public float czasGry = 0.0f;
   


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
   
    private void Update()
    {
        czasGry += Time.deltaTime;
        timer += Time.deltaTime;
        if (uderzenie == 1)
        {
            if (timer > 1.25f)
            {
                transform.position = miejsceRespawnu;
                if (timer > 1.77f)
                {
                    zranienie = 0;
                    uderzenie = 0;

                }
            }
        }
            PlayerPrefs.SetInt("Zran", zranienie); 

    }

    private void OnCollisionEnter2D(Collision2D Player)
    {
        if (Player.gameObject.tag == "Enemy" && EnemyScript.zniszcz == false)
        {
            if (zranienie != 1)
            {
                timer = 0.0f;
                zranienie = 1;
                uderzenie = 1;
                Zycie.zycie -= 1;
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (zranienie != 1)
        {
            if (Player.tag == "Fall")
            {
                timer = 0.0f;
                zranienie = 1;
                uderzenie = 1;
                Zycie.zycie -= 1;
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

                timer = 0.0f;
                zranienie = 1;
                uderzenie = 1;
                Zycie.zycie -= 1;

            }

            if (Player.tag == "Moneta")
            {
                punktacja.wynik++;
            }

            if (Player.tag == "ZycieUP")
            {
                Zycie.zycie ++;
            }
        }
    }
}