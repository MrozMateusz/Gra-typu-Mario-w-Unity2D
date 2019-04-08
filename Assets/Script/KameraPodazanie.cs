using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraPodazanie : MonoBehaviour
{
    GameObject Gracz;
    Vector3 pozycjaGracza;
    
    private void Start()
    {
        Gracz = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        pozycjaGracza = new Vector3(Gracz.transform.position.x, transform.position.y, transform.position.z);
       
        transform.position = pozycjaGracza;
    }
}
