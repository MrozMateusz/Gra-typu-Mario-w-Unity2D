using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Scene scena;
    public GameObject kon;
    public int mozKonWyg = 1;

    // Start is called before the first frame update
    void Start()
    {
        scena = SceneManager.GetActiveScene();
        mozKonWyg = 1;
        PlayerPrefs.SetInt("MozKonWyg", mozKonWyg);
    }

    void Update()
    {  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
            if (scena.name == "Plansza1")
            {
                kon.SetActive(true);
                Cursor.visible = true;
                mozKonWyg = 0;
                Time.timeScale = 0.0f;
                PlayerPrefs.SetInt("MozKonWyg", mozKonWyg);
            }
            else
            {
                mozKonWyg = 1;
                PlayerPrefs.SetInt("MozKonWyg", mozKonWyg);
            }
        }
    }

}
