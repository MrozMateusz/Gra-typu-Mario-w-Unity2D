using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaw : MonoBehaviour
{
    public Vector3 miejsceRespawnu;
    private GameObject respawnPlace;

    void Start()
    {
        respawnPlace = GameObject.Find("Respawn");
        miejsceRespawnu = respawnPlace.transform.position;
        
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
        }
        if (Player.tag == "Trap")
        {
            transform.position = miejsceRespawnu;
        }
    }
}