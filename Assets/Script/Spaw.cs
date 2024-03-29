﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class Spaw : MonoBehaviour
{
    public static Vector3 miejsceRespawnu;
    public static Vector3 poczresp;
    private GameObject respawnPlace;
    private int scena;
    private Animator animacja;
    float timer = 0.0f;
    float timerA = 0.0f;
    public int zranienie = 0;
    public int uderzenie = 0;
    bool zebrane = false;
    bool zm_kam_przy_spad = false;
    bool zm_kam_przy_skoku = false;

    public AudioSource dzwiekMon;
    public AudioSource dzwiekHealth;
    public AudioSource dzwiekCheck;
    public AudioSource FallDz;

    float czasZmianyKamery = 0.0f;

    void Start()
    {
        if (!PlayerPrefs.HasKey("MozKonWyg"))
        {
            PlayerPrefs.SetInt("MozKonWyg", 1);
        }
        if (!PlayerPrefs.HasKey("MozKon"))
        {
            PlayerPrefs.SetInt("MozKon", 1);
        }

        if (PlayerPrefs.GetFloat("PozX")!=0 && PlayerPrefs.GetFloat("PozY") != 0 && PlayerPrefs.GetFloat("PozZ") != 0 && MenedzerMenu.klik_konty == true)
                {
                    
                    miejsceRespawnu = new Vector3(PlayerPrefs.GetFloat("PozX"), PlayerPrefs.GetFloat("PozY"), PlayerPrefs.GetFloat("PozZ"));
                    this.transform.position = miejsceRespawnu;
            MenedzerMenu.klik_konty = false;
                }
                else {
        respawnPlace = GameObject.FindGameObjectWithTag("Respawn");
            miejsceRespawnu = respawnPlace.transform.position;
            this.transform.position = miejsceRespawnu;

            poczresp = miejsceRespawnu;

            if(MenedzerMenu.gra_od_nowa == true)
            {
                miejsceRespawnu = poczresp;
                MenedzerMenu.gra_od_nowa = false;
            }
           
        }

        if (Win.zmiana == true)
        {
            respawnPlace = GameObject.FindGameObjectWithTag("Respawn");
            miejsceRespawnu = respawnPlace.transform.position;
            this.transform.position = miejsceRespawnu;

            poczresp = miejsceRespawnu;
        }

    }

    private void Update()
    {
        czasZmianyKamery += Time.deltaTime;
        timer += Time.deltaTime;
        timerA += Time.deltaTime;

        if(czasZmianyKamery > 1.5f)
        {
            if (zm_kam_przy_skoku == true)
            {
                KameraPodazanie.zmiana_sp_por_kam = false;
                zm_kam_przy_skoku = false;
            }
        }

        if (uderzenie == 1)
        {
            if (timer > 1.25f)
            {
                transform.position = miejsceRespawnu;

                    if (zm_kam_przy_spad == true)
                    {
                        KameraPodazanie.zmiana_sp_por_kam = true;
                        zm_kam_przy_spad = false;
                    }

                if (timer > 1.77f)
                {
                    zranienie = 0;
                    uderzenie = 0; 
                }
            }
        }
            PlayerPrefs.SetInt("Zran", zranienie); 

        if(timerA > 0.05f)
        {
            zebrane = false;
        }

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
                Zycie.blokada = false;
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
                FallDz.Play();
            }

            if (Player.tag == "CameraUP")
            {
                if (KameraPodazanie.zmiana_sp_por_kam == true)
                {
                    KameraPodazanie.zmiana_sp_por_kam = false;
                    zm_kam_przy_spad = true;
                }
            }

            if (Player.tag == "CameraZbyWysoko")
            {
                if (KameraPodazanie.zmiana_sp_por_kam == false)
                {
                    KameraPodazanie.zmiana_sp_por_kam = true;
                    zm_kam_przy_skoku = true;
                    czasZmianyKamery = 0.0f;
                }
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
               
                    dzwiekCheck.Play();
                
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
                if (zebrane == false)
                {
                    if (PlayerPrefs.GetInt("PoziomTr") == 1)
                    {
                        punktacja.wynik++;
                    }
                    else if (PlayerPrefs.GetInt("PoziomTr") == 2)
                    {
                       punktacja.wynik = punktacja.wynik + 2;
                    }
                    else if (PlayerPrefs.GetInt("PoziomTr") == 3)
                    {
                        punktacja.wynik = punktacja.wynik + 3;
                    }
                    Zycie.blokada = false;
                    zebrane = true;
                    dzwiekMon.Play();
                }

            }

            if (Player.tag == "ZycieUP")
            {
                if (zebrane == false)
                {
                    Zycie.zycie++;
                    zebrane = true;
                    dzwiekHealth.Play();
                }
            }
        }
    }
}