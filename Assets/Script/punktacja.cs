using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punktacja : MonoBehaviour
{
    GameObject pl;
    public int wynik = 0;

    // Start is called before the first frame update
    void Start()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("WynikZapis", wynik);
        
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        if(Player.tag == "Moneta")
        {
            wynik = wynik + 1;
        }

    }
}
