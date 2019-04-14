using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CzasGry : MonoBehaviour
{
    float CzasPocz;
    float czas;
    static public float minuty;
    static public float sekundy;
    static public string CzasR;
    bool koniec;


    // Start is called before the first frame update
    void Start()
    {
        CzasPocz = Time.time;
        koniec = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (koniec == false)
        {
            czas = Time.time - CzasPocz;

            minuty = ((int)czas / 60);
            sekundy = (czas % 60);
        }
        
        CzasR = minuty + ":" + sekundy.ToString("f0");
        Koniec();
    }

    void Koniec()
    {
        if (Zycie.zycie < 1)
        {
            koniec = true;
        }
    }

}
