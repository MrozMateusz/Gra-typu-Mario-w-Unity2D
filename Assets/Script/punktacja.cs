using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punktacja : MonoBehaviour
{

    public int wynik = 0;

    // Start is called before the first frame update
    void Start()
    {   
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

    public void OnGUI()
    {
        GUI.backgroundColor = Color.black;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(10, 46, 800, 600), "Wynik: " + wynik);
    }

}
