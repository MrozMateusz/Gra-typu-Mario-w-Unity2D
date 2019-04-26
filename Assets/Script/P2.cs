using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2 : MonoBehaviour
{
    public GameObject gm;

    void Start()
    {
        if (PlayerPrefs.GetInt("PoziomTr") == 1)
        {
            gm.SetActive(false);
        }

    }
}
