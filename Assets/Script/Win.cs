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

    // Start is called before the first frame update
    void Start()
    {
        x = 2;
        mozKonWyg = 1;
        PlayerPrefs.SetInt("MozKonWyg", mozKonWyg);

    }

    void Update()
    {
        timerZ = Time.deltaTime;

        scena = SceneManager.GetActiveScene();

        if (kon.activeSelf == true)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }

        if(timerZ > 0.5f)
        {
            if (zmiana == true)
            {
                x++;
            }
            zmiana = false;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            if (scena.buildIndex != 2)
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
            }
            
        }
    }

}
