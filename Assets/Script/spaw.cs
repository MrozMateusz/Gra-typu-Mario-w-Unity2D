using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class spaw : MonoBehaviour
{
    public Vector3 miejsceRespawnu;
    private GameObject respawnPlace;
    private int scena;
    public GameObject PlayerPrefab;

    void Awake()
    {

    if(PlayerPrefs.GetFloat("PozX")!=0 && PlayerPrefs.GetFloat("PozY") != 0 && PlayerPrefs.GetFloat("PozZ") != 0)
        {
            float PX = PlayerPrefs.GetFloat("PozX");
            miejsceRespawnu = new Vector3(PlayerPrefs.GetFloat("PozX"), PlayerPrefs.GetFloat("PozY"), PlayerPrefs.GetFloat("PozZ"));
           // Instantiate(PlayerPrefab, miejsceRespawnu, Quaternion.identity);
        }
        else {
           // Instantiate(PlayerPrefab, miejsceRespawnu, Quaternion.identity);
            respawnPlace = GameObject.Find("Respawn");
            miejsceRespawnu = respawnPlace.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D Player)
    {
        if (Player.gameObject.tag == "Enemy")
        {
            transform.position = miejsceRespawnu;
        }
    }


    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.tag=="Fall")
        {
            transform.position = miejsceRespawnu;
        }
        if (Player.tag == "Enemy")
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
            transform.position = miejsceRespawnu;
        }
    }
}