using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P3 : MonoBehaviour
{
    public GameObject gm;


    void Start()
    {
        if (PlayerPrefs.GetInt("PoziomTr") == 1)
        {
            gm.SetActive(false);
        }

        if (PlayerPrefs.GetInt("PoziomTr") == 2)
        {
            gm.SetActive(false);
        }

    }
}
