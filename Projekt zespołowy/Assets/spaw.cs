using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaw : MonoBehaviour
{
    public Transform Respawn;
    public Transform play;
    public GameObject go;


    private void Update()
    {
       if( go = GameObject.Find("Respawn"))
        {
            Debug.Log("istnieje");
        }

        if (Input.GetKeyDown(KeyCode.R)){

            
            play.transform.position = Respawn.position;
            Debug.Log("r key was pressed.");
        }
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.name=="Fall")
        {
            play.transform.position = Respawn.position;
        }
    }
}