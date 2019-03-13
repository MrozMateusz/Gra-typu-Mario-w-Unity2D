using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraPodazanie : MonoBehaviour
{
    public GameObject Gracz;
    Vector3 pozycjaGracza;
 
    // Update is called once per frame
    void FixedUpdate()
    {
        pozycjaGracza = new Vector3(Gracz.transform.position.x, transform.position.y, transform.position.z);
       
        transform.position = pozycjaGracza;
    }
}
