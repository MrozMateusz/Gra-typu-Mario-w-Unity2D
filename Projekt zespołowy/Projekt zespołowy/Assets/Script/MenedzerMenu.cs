using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenedzerMenu : MonoBehaviour
{ 
    public Canvas menu;
    public GameObject op;
    public GameObject men;
    Scene scena;
    
    
    public void NowaGra(string Plansza1)
    {
        SceneManager.LoadScene(Plansza1);
    }

    public void Wyjscie()
    {
        Application.Quit();
    }

    public void Opcje()
    {
        men.SetActive(false);
        op.SetActive(true);
    }

    void Start()
    {
        scena = SceneManager.GetActiveScene();
        if (scena.name == "Plansza1")
        {
            men.SetActive(false);
        }
    }

    public void Zatwierdz()
    {
        men.SetActive(true);
        op.SetActive(false);
    }

    public void PowrotDoMenu(string Menu)
    {
        SceneManager.LoadScene(Menu);
        Time.timeScale = 1;
    }

    public void PowrotDoGry(GameObject men)
    {
        men.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1;


    }
    
    void Update()
    {
        if (scena.name == "Plansza1")
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                men.SetActive(true);
                menu.enabled = !menu.enabled;
                if (menu.enabled)
                {
                    Time.timeScale = 0;
                    Cursor.visible = enabled;
                }
                else
                {
                    Cursor.visible = false;
                    Time.timeScale = 1;
                }
            }
        }
        
    }

}
