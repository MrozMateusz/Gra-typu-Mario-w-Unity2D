using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
    private int scenazapisu;

    private void Awake()
    {
       PlayerPrefs.SetInt("rozdzielczoscSzer",Screen.width);
        PlayerPrefs.SetInt("rozdzielczoscWys", Screen.height);
        PlayerPrefs.SetFloat("Glosnosc", AudioListener.volume);

        if (File.Exists(Application.persistentDataPath + "/UstawieniaDomyslne.d"))
        {
            BinaryFormatter Form = new BinaryFormatter();
            FileStream zapisUst = File.Open(Application.persistentDataPath + "/UstawieniaDomyslne.d", FileMode.Open);
            Save ustawienia = (Save)Form.Deserialize(zapisUst);
            Screen.SetResolution(ustawienia.szerEkranu, ustawienia.wysEkranu, fs);
            AudioListener.volume = ustawienia.Glosnosc;

            zapisUst.Close();
        }

    }

    public void NowaGra(string Plansza1)
    {
        SceneManager.LoadScene(Plansza1);
        PlayerPrefs.SetFloat("PozX", -2.091f);
        PlayerPrefs.SetFloat("PozY", -3.497f);
        PlayerPrefs.SetFloat("PozZ", 13.582f);
    }

    public void Kontynuuj()
    {
        int OstatniaPlansza;
    
            if (File.Exists(Application.persistentDataPath + "/ZapisanaGra.d"))
            {
                BinaryFormatter Forma = new BinaryFormatter();
                FileStream zapisGry = File.Open(Application.persistentDataPath + "/ZapisanaGra.d", FileMode.Open);
                ZapisGry zapisG = (ZapisGry)Forma.Deserialize(zapisGry);
                OstatniaPlansza = zapisG.Plansza;
            PlayerPrefs.SetFloat("PozX", zapisG.PlayerX);
            PlayerPrefs.SetFloat("PozY", zapisG.PlayerY);
            PlayerPrefs.SetFloat("PozZ", zapisG.PlayerZ);
            PlayerPrefs.Save();

            zapisGry.Close();

            if (OstatniaPlansza != 0)
            {
                SceneManager.LoadScene(OstatniaPlansza);
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
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
        BinaryFormatter Forma = new BinaryFormatter();
        FileStream zapisGry = File.Create(Application.persistentDataPath + "/ZapisanaGra.d");
        ZapisGry zapis= new ZapisGry();

        zapis.Plansza = PlayerPrefs.GetInt("ZapisanaPlansza");
        zapis.PlayerX = PlayerPrefs.GetFloat("PolX");
        zapis.PlayerY = PlayerPrefs.GetFloat("PolY");
        zapis.PlayerZ = PlayerPrefs.GetFloat("PolZ");

        Forma.Serialize(zapisGry, zapis);
        zapisGry.Close();

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

        BinaryFormatter Form = new BinaryFormatter();
        FileStream zapisUst = File.Create(Application.persistentDataPath + "/UstawieniaDomyslne.d");
        Save ustawienia = new Save();

        ustawienia.fullscreen = fs;
        ustawienia.szerEkranu = PlayerPrefs.GetInt("rozdzielczoscSzer");
        ustawienia.wysEkranu = PlayerPrefs.GetInt("rozdzielczoscWys");
        ustawienia.Glosnosc= PlayerPrefs.GetFloat("Glosnosc");

        Form.Serialize(zapisUst, ustawienia);
        zapisUst.Close();

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
    [Serializable]
    class Save
    {
        public int wysEkranu;
        public int szerEkranu;
        public float Glosnosc;
        public bool fullscreen;

    }

    [Serializable]
    class ZapisGry
    {
        public float PlayerX;
        public float PlayerY;
        public float PlayerZ;
        public int Plansza;
       // public string nick;
      //  public int wynik;
       // public int ilZycie;
    }

}
