using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenedzerMenu : MonoBehaviour
{
    public Canvas menuInGameCanvas;
    public GameObject op;
    public GameObject menuInGame;
    public GameObject helpMenu;
    public Canvas helpMenuCanvas;
    Scene scena;
    private Double lastTimeKeyPressed;


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
        menuInGame.SetActive(false);
        op.SetActive(true);
    }

    void Start()
    {
        scena = SceneManager.GetActiveScene();
        if (scena.name == "Plansza1")
        {
            menuInGame.SetActive(false);
        }
    }

    public void Zatwierdz()
    {
        menuInGame.SetActive(true);
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

    private bool canBePressed() //żeby nie włączało się po kilka razy np. menu w grze
    {
        if (Time.time - lastTimeKeyPressed > 0.1)
        {
            lastTimeKeyPressed = Time.time;
            return true;
        }
        return false;
    }

    void helpMenuUpdate()
    {
        if (Input.GetKey(KeyCode.F1) && canBePressed())
        {

            helpMenu.SetActive(true);
            helpMenuCanvas.enabled = true;


        }
        if (helpMenu.activeSelf && Input.GetKey(KeyCode.Escape) && canBePressed())
        {
            helpMenu.SetActive(false);
            helpMenuCanvas.enabled = false;
        }
    }
    void Update()
    {
        if (scena.name == "Plansza1")
        {
            if (Input.GetKey(KeyCode.Escape) && !helpMenu.activeSelf && canBePressed())
            {
                menuInGame.SetActive(true);
                menuInGameCanvas.enabled = !menuInGameCanvas.enabled;
                if (menuInGameCanvas.enabled)
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
            helpMenuUpdate();
        }

    }

}
