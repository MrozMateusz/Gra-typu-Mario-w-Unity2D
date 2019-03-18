using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenedzerMenu : MonoBehaviour
{
    public Canvas menuInGameCanvas;
    public GameObject op;
    public GameObject menuInGame;
    public GameObject helpMenu;
    public Canvas helpMenuCanvas;
    public GameObject zapis_opcji;
    Scene scena;
    private Double lastTimeKeyPressed;
    public GameObject menu_wyj;

    bool fs;

    private void Awake()
    {
        PlayerPrefs.SetInt("rozdzielczoscSzer",Screen.width);
        PlayerPrefs.SetInt("rozdzielczoscWys", Screen.height);
        fs = Screen.fullScreen;
        PlayerPrefs.SetFloat("Glosnosc", AudioListener.volume);

    }

    public void NowaGra(string Plansza1)
    {
        SceneManager.LoadScene(Plansza1);

    }

    public void Wyjscie()
    {
        menu_wyj.SetActive(true);
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
        zapis_opcji.SetActive(true);
      
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
    public void Tak()
    {
        Application.Quit();
    }

    public void Nie()
    {
        menu_wyj.SetActive(false);
    }

    public void Pomoc()
    {
        helpMenu.SetActive(true);
        menuInGame.SetActive(false);
    }

    public void Zapisz()
    {
        PlayerPrefs.SetInt("rozdzielczoscSzer", Screen.width);
        PlayerPrefs.SetInt("rozdzielczoscWys", Screen.height);
        fs = Screen.fullScreen;
        PlayerPrefs.SetFloat("Glosnosc", AudioListener.volume);
        

        menuInGame.SetActive(true);
        op.SetActive(false);
        zapis_opcji.SetActive(false);
    }

    public void NieZapisuj()
    {
        Screen.SetResolution(PlayerPrefs.GetInt("rozdzielczoscSzer"), PlayerPrefs.GetInt("rozdzielczoscWys"), Screen.fullScreen = fs);
        AudioListener.volume=PlayerPrefs.GetFloat("Glosnosc");
        zapis_opcji.SetActive(false);
        menuInGame.SetActive(true);
        op.SetActive(false);
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
            Time.timeScale = 1;
        }
    }
    void Update()
    {
        if (scena.name == "Plansza1")
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !helpMenu.activeSelf)
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
