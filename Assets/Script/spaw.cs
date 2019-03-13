using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaw : MonoBehaviour
{
    public Vector3 miejsceRespawnu;

    void Start()
    {
        miejsceRespawnu = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.tag=="Fall")
        {
            transform.position = miejsceRespawnu;
            Debug.Log("Jest, spadlem");
        }
        if (Player.tag == "Checkpoint")
        {
            miejsceRespawnu = Player.transform.position;
        }
    }
}