using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Czas_stop : MonoBehaviour
{
    Canvas menu_w_grze;
    public static bool blok_skok = false;
    // Start is called before the first frame update
    void Start()
    {
        menu_w_grze = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if (menu_w_grze.enabled)
        {
            Time.timeScale = 0.0f;
            blok_skok = true;
        }
        else
        {
            Time.timeScale = 1.0f;
            blok_skok = false;
        }


    }
}
