using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Scene scena;
    public GameObject kon;
    public int mozKonWyg = 1;
    public int x; 
    public float timerZ = 0.0f;
    public static bool zmiana = false;
    public static bool czas_zatrzym = false;

    //Skrypt kończący grę


    void Start()
    {
        x = 2;
        mozKonWyg = 1;
        PlayerPrefs.SetInt("MozKonWyg", mozKonWyg);
        if (zmiana == true)
        {
            x++;
        }
        if (MenedzerMenu.gra_od_nowa == true)
        {
            x = 2;
        }
    }

    void Update()
    {
        

        timerZ = Time.deltaTime;

        scena = SceneManager.GetActiveScene();

        if (kon.activeSelf)
        {
            Time.timeScale = 0;
            czas_zatrzym = true;
        }
        else
        {
           Time.timeScale = 1;
            czas_zatrzym = false;
        }
        
        if (timerZ > 0.5f)
        { 
            zmiana = false; 
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            if (scena.buildIndex != 3)
            {
                SceneManager.LoadScene(x);
                zmiana = true;
                timerZ = 0.0f;

            }
            else
            {
            
                kon.SetActive(true);
                Cursor.visible = true;
                mozKonWyg = 0;
                x = 2;

                PlayerPrefs.SetInt("MozKonWyg", mozKonWyg);

                if (PlayerPrefs.GetInt("ostPozTr") != 2) {
                    if (PlayerPrefs.GetInt("PoziomTr") == 1)
                    {
                        PlayerPrefs.SetInt("ostPozTr", 1);
                    }
                    else if (PlayerPrefs.GetInt("PoziomTr") == 2)
                    {
                        PlayerPrefs.SetInt("ostPozTr", 2);
                    }
                }
            }
            
        }
    }

}
