using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraPodazanie : MonoBehaviour
{
    GameObject Gracz;
    Vector3 pozycjaGracza;
    public float lekkiePrzejścia = 0.125f;
    Vector3 smuklaPozycja;


    private void Start()
    {
        Gracz = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
      
            pozycjaGracza = new Vector3(Gracz.transform.position.x, Gracz.transform.position.y, transform.position.z);
            smuklaPozycja = Vector3.Lerp(transform.position, pozycjaGracza, lekkiePrzejścia);
            transform.position = smuklaPozycja;
 
    }

}
