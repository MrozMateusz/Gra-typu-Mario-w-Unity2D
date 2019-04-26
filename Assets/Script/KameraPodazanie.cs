using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraPodazanie : MonoBehaviour
{
    GameObject Gracz;
    Vector3 pozycjaGracza;
    public float lekkiePrzejścia = 0.125f; //prędkość kamery, przy smukłym przejściu
    Vector3 smuklaPozycja;
    public static bool zmiana_sp_por_kam = false;
    float zm_y;

    //Ustawienie kamery, aby śledziła gracza tylko w osi x lub też w osi y

    private void Start()
    {
        Gracz = GameObject.FindWithTag("Player");
        zmiana_sp_por_kam = PlayerPrefsX.GetBool("Kam");
        zm_y = transform.position.y;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (zmiana_sp_por_kam == false)
        {
            
            pozycjaGracza = new Vector3(Gracz.transform.position.x, zm_y, transform.position.z);
            smuklaPozycja = Vector3.Lerp(transform.position, pozycjaGracza, lekkiePrzejścia);
            transform.position = smuklaPozycja;
        }
        else
        {
            pozycjaGracza = new Vector3(Gracz.transform.position.x, Gracz.transform.position.y, transform.position.z);
            smuklaPozycja = Vector3.Lerp(transform.position, pozycjaGracza, lekkiePrzejścia);
            transform.position = smuklaPozycja;
        }
 
    }

}
