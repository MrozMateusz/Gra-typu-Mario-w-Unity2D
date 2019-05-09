using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public class MenedzerMenu : MonoBehaviour
{
    KeyCode ESCW, F1W;
    public Canvas menuInGameCanvas;
    public GameObject op;
    public GameObject TW;
    public GameObject WDG;
    public GameObject menuInGame;
    public GameObject helpMenu;
    public Canvas helpMenuCanvas;
    public GameObject zapis_opcji;
    public GameObject wybor_trud;
    public GameObject helpERROR;
    Scene scena;
    private Double lastTimeKeyPressed;
    public GameObject menu_wyj;
    Resolution roz;
    readonly string naz = "Menu";
    public InputField input;
    public GameObject kon;
    public GameObject helpPocz;
    public Button btkon;
    public Button rozp;
    public Button czysc;
    public Button btTaWy;
    public Button btPozTrSr;
    public Button btPozTrTR;
    string nick;
    float timer = 0.0f;
    bool gotowy_do_czyszcz = false;
    public static bool wyczyszczony = false;
    public bool blokada = true;
    public static bool gra_od_nowa = false;
    public int Poziom_tr;
    public static bool czas_stop = false;
    public static bool klik_konty = false;


    int[] TablicaWynikow = new int[10];
    string[] TablicaWynikowNick = new string[10];

    bool fs;
    private int scenazapisu;

    private void Awake()
    {

        if (!PlayerPrefs.HasKey("ostPozTr"))
        {
            PlayerPrefs.SetInt("ostPozTr", 0);
        }

        Cursor.visible = enabled;
        PlayerPrefs.SetInt("rozdzielczoscSzer",Screen.width);
        PlayerPrefs.SetInt("rozdzielczoscWys", Screen.height);
        PlayerPrefs.SetFloat("Glosnosc", AudioListener.volume);
        PlayerPrefsX.SetBool("FS", Screen.fullScreen);

        if (File.Exists(Application.persistentDataPath + "/UstawieniaDomyslne.d"))
        {
            BinaryFormatter Form = new BinaryFormatter();
            FileStream zapisUst = File.Open(Application.persistentDataPath + "/UstawieniaDomyslne.d", FileMode.Open);
            Save ustawienia = (Save)Form.Deserialize(zapisUst);
            Screen.SetResolution(ustawienia.szerEkranu, ustawienia.wysEkranu, ustawienia.fullscreen);
            AudioListener.volume = ustawienia.Glosnosc;

            zapisUst.Close();
        }

    }

    public void NowaGra()
    {
        if (PlayerPrefs.HasKey("Up"))
        {
            WDG.SetActive(true);
        menuInGame.SetActive(false);
        }
        else
        {
            helpERROR.SetActive(true);
            menuInGame.SetActive(false);
        }
    }

    public void Graj_od_Nast_Poz_trud()
    {
        SceneManager.LoadScene(4);
    }

    public void OK()
    {
        helpERROR.SetActive(false);
        menuInGame.SetActive(true);
    }

    public void wpisz()
    {
        rozp.interactable = false;
        nick = input.text;

        if (input.text.Length > 0)
        {

            PlayerPrefs.SetString("NicK", nick);
            blokada = false;
        }
        else
        {
            blokada = true;
        }
        
    }
    
    public void WybierzPoziomTrud()
    {
        wybor_trud.SetActive(true);
        WDG.SetActive(false);
   
    }

    public void P1(string Plansza1)
    {
        SceneManager.LoadScene(Plansza1);
        PlayerPrefs.SetFloat("PozX", -10.77f);
        PlayerPrefs.SetFloat("PozY", -2.86f);
        PlayerPrefs.SetFloat("PozZ", 13.6342f);
        PlayerPrefs.SetInt("Wynik", 0);
        PlayerPrefs.SetInt("ILZY", 3);
        PlayerPrefs.SetInt("PoziomTr", 1);
        PlayerPrefs.GetString("NicK");
    }

    public void P2(string Plansza1)
    {
        SceneManager.LoadScene(Plansza1);
        PlayerPrefs.SetFloat("PozX", -10.77f);
        PlayerPrefs.SetFloat("PozY", -2.86f);
        PlayerPrefs.SetFloat("PozZ", 13.6342f);
        PlayerPrefs.SetInt("Wynik", 0);
        PlayerPrefs.SetInt("ILZY", 2);
        PlayerPrefs.SetInt("PoziomTr", 2);
        PlayerPrefs.GetString("NicK");
    }

    public void P3(string Plansza1)
    {
        SceneManager.LoadScene(Plansza1);
        PlayerPrefs.SetFloat("PozX", -10.77f);
        PlayerPrefs.SetFloat("PozY", -2.86f);
        PlayerPrefs.SetFloat("PozZ", 13.6342f);
        PlayerPrefs.SetInt("Wynik", 0);
        PlayerPrefs.SetInt("ILZY", 4);
        PlayerPrefs.SetInt("PoziomTr", 3);
        PlayerPrefs.GetString("NicK");
    }

    public void PowrZWybPoziTrud()
    {
        wybor_trud.SetActive(false);
        menuInGame.SetActive(true);
    }

    public void WrocDoMenu()
    {
        WDG.SetActive(false);
        menuInGame.SetActive(true);
        Time.timeScale = 1;
    }

    public void WDOMENU(string Menu)
    {
        SceneManager.LoadScene(Menu);
        Time.timeScale = 1;
    }

    public void Kontynuuj()
    {
            int OstatniaPlansza;
        if (PlayerPrefs.HasKey("Up"))
        {
            if (File.Exists(Application.persistentDataPath + "/ZapisanaGra.d"))
            {
                BinaryFormatter Forma = new BinaryFormatter();
                FileStream zapisGry = File.Open(Application.persistentDataPath + "/ZapisanaGra.d", FileMode.Open);
                ZapisGry zapisG = (ZapisGry)Forma.Deserialize(zapisGry);
                OstatniaPlansza = zapisG.Plansza;
                PlayerPrefs.SetFloat("PozX", zapisG.PlayerX);
                PlayerPrefs.SetFloat("PozY", zapisG.PlayerY);
                PlayerPrefs.SetFloat("PozZ", zapisG.PlayerZ);
                PlayerPrefs.SetInt("Wynik", zapisG.wynik);
                PlayerPrefs.SetInt("ILZY", zapisG.ilZycie);
                PlayerPrefs.SetString("NicK", zapisG.nick);
                PlayerPrefs.SetInt("PoziomTr", zapisG.poziomTr);
                PlayerPrefs.Save();

                zapisGry.Close();

            Time.timeScale = 1;

                klik_konty = true;

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
        else
        {
            helpERROR.SetActive(true);
            menuInGame.SetActive(false);
        }
    }

    public void Wyjscie()
    {
        menu_wyj.SetActive(true);
        menuInGame.SetActive(false);
    }

    public void TablicaWynikowM()
    {
        menuInGame.SetActive(false);
        TW.SetActive(true);
    }

    public void PowrotZTablicyWynikow()
    {
        menuInGame.SetActive(true);
        TW.SetActive(false);
    }

    public void Opcje()
    {
            menuInGame.SetActive(false);
            op.SetActive(true);
    }

    void Start()
    {
        
        if (PlayerPrefsX.GetIntArray("TablicaWynikow", 0, 10)[0] == 0) {

            int[] TablicaWynikow = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

            PlayerPrefsX.SetIntArray("TablicaWynikow", TablicaWynikow);
        }

        if (PlayerPrefsX.GetStringArray("TablicaWynikowNick", "", 10)[0] == "")
        {

            string[] TablicaWynikowNick = new string[10] {"", "" , "" , "" , "", "" , "" , "" , "" , "" };

            PlayerPrefsX.SetStringArray("TablicaWynikowNick", TablicaWynikowNick);
        }

        scena = SceneManager.GetActiveScene();
        if (scena.name != naz)
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
        zapis.wynik = PlayerPrefs.GetInt("Wynik");
        zapis.ilZycie = PlayerPrefs.GetInt("ILZY");
        zapis.nick = PlayerPrefs.GetString("NicK");
        zapis.poziomTr = PlayerPrefs.GetInt("PoziomTr");

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
        menuInGame.SetActive(true);
    }

    public void Pomoc()
    {
        helpMenu.SetActive(true);
        menuInGame.SetActive(false);
    }

    public void ZaGraczemKam()
    {
        KameraPodazanie.zmiana_sp_por_kam = true;
        PlayerPrefsX.SetBool("Kam", KameraPodazanie.zmiana_sp_por_kam);
    }

    public void StatycznaKam()
    {
        KameraPodazanie.zmiana_sp_por_kam = false;
        PlayerPrefsX.SetBool("Kam", KameraPodazanie.zmiana_sp_por_kam);
    }

    public void GrajOdNowa()
    {
        SceneManager.LoadScene(1);
        kon.SetActive(false);
        if (PlayerPrefs.GetInt("PoziomTr") == 1)
        {
            Zycie.zycie = 3;
        }
        else if (PlayerPrefs.GetInt("PoziomTr") == 2)
        {
            Zycie.zycie = 2;
        }
        else if (PlayerPrefs.GetInt("PoziomTr") == 3)
        {
            Zycie.zycie = 4;
        }
        punktacja.wynik = 0;
        CzasGry.minuty = 0.0f;
        CzasGry.sekundy = 0.0f;
        Time.timeScale = 1;
        gra_od_nowa = true;
    }
 
    public void Zapisz()
    {
        PlayerPrefs.SetInt("rozdzielczoscSzer", Screen.width);
        PlayerPrefs.SetInt("rozdzielczoscWys", Screen.height);
        PlayerPrefs.SetInt("RefRat", roz.refreshRate);
        PlayerPrefsX.SetBool("FS",Screen.fullScreen);
        PlayerPrefs.SetFloat("Glosnosc", AudioListener.volume);


        BinaryFormatter Form = new BinaryFormatter();
        FileStream zapisUst = File.Create(Application.persistentDataPath + "/UstawieniaDomyslne.d");
        Save ustawienia = new Save();

        ustawienia.fullscreen = PlayerPrefsX.GetBool("FS");
        ustawienia.szerEkranu = PlayerPrefs.GetInt("rozdzielczoscSzer");
        ustawienia.wysEkranu = PlayerPrefs.GetInt("rozdzielczoscWys");
        ustawienia.refRate = PlayerPrefs.GetInt("RefRat");
        ustawienia.Glosnosc = PlayerPrefs.GetFloat("Glosnosc");

        Form.Serialize(zapisUst, ustawienia);
        zapisUst.Close();

        menuInGame.SetActive(true);
        op.SetActive(false);
        zapis_opcji.SetActive(false);
    }

    public void NieZapisuj()
    {
        Screen.SetResolution(PlayerPrefs.GetInt("rozdzielczoscSzer"), PlayerPrefs.GetInt("rozdzielczoscWys"), PlayerPrefsX.GetBool("FS"), PlayerPrefs.GetInt("RefRat"));
        AudioListener.volume = PlayerPrefs.GetFloat("Glosnosc");
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

    public void PomocMG()
    {
        if (PlayerPrefs.HasKey("Up"))
        {
            menuInGame.SetActive(false);
        helpMenu.SetActive(true);
        }
        else
        {
            helpERROR.SetActive(true);
            menuInGame.SetActive(false);
        }
    }

    public void Czysc()
    {

        if (gotowy_do_czyszcz == false)
        {
            Debug.Log("Lista Pusta");
        }
        else
        {
            int[] TablicaWynikow = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            PlayerPrefsX.SetIntArray("TablicaWynikow", TablicaWynikow);


            string[] TablicaWynikowNick = new string[10] { "", "", "", "", "", "", "", "", "", "" };

            PlayerPrefsX.SetStringArray("TablicaWynikowNick", TablicaWynikowNick);
            timer = 0.0f;
            wyczyszczony = true;
       } 
   }

    void helpMenuUpdate()
    {
        if (Input.GetKey(F1W) && canBePressed() && !helpPocz.activeSelf && !menuInGameCanvas.enabled && !kon.activeSelf)
        {

            helpMenu.SetActive(true);
            Time.timeScale = 0;


        }
        if (helpMenu.activeSelf && Input.GetKey(ESCW) && canBePressed())
        {
            helpMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void WyjdzZPom()
    {
        helpMenu.SetActive(false);
        menuInGame.SetActive(true);
    }

    public void PowrotZPomocy()
    {
        menuInGame.SetActive(true);
        helpMenu.SetActive(false);

    }


    void Update()
    {
        TablicaWynikow = PlayerPrefsX.GetIntArray("TablicaWynikow");
        TablicaWynikowNick = PlayerPrefsX.GetStringArray("TablicaWynikowNick");

        if (PlayerPrefs.HasKey("ESC"))
            ESCW = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ESC"));
        if (PlayerPrefs.HasKey("F1"))
            F1W = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("F1"));

        if (scena.name != naz)
        {
            if (helpMenu.activeSelf || menuInGameCanvas.enabled || kon.activeSelf)
            {
                Cursor.visible = enabled;
            }
            else
            {
                Cursor.visible = false;
            }

            if (Input.GetKeyDown(ESCW) && helpPocz.activeSelf)
            {
                helpPocz.SetActive(false);

            }
                if (Input.GetKeyDown(ESCW) && !helpMenu.activeSelf && !helpPocz.activeSelf && !kon.activeSelf)
               {
                menuInGame.SetActive(true);
                menuInGameCanvas.enabled = !menuInGameCanvas.enabled;
                if (menuInGameCanvas.enabled)
                {
                    Cursor.visible = enabled;
                }
                else
                {
                    Cursor.visible = false;
                }
                
            }
            helpMenuUpdate();
        }
        else
        {
            if (PlayerPrefs.GetInt("MozKon") == 1 && PlayerPrefs.GetInt("MozKonWyg") == 1)
            {
                btkon.interactable = true;
            }
            else
            {
                btkon.interactable = false;
            }

            if (PlayerPrefs.GetInt("ostPozTr") == 0)
            {
                btPozTrSr.interactable = false;
                btPozTrTR.interactable = false;
            }
            else if(PlayerPrefs.GetInt("ostPozTr") == 1)
            {
                btPozTrSr.interactable = true;
                btPozTrTR.interactable = false;
            }
            else if(PlayerPrefs.GetInt("ostPozTr") == 2)
            {
                btPozTrSr.interactable = true;
                btPozTrTR.interactable = true;
            }


            timer += Time.deltaTime;

            if (TablicaWynikow[0] == 0 || TablicaWynikowNick[0] == "")
            {
                gotowy_do_czyszcz = false;
            }
            else
            {
                gotowy_do_czyszcz = true;
            }

            if(timer > 0.5f)
            {
                wyczyszczony = false;
            }

        if (gotowy_do_czyszcz == true)
        {
            czysc.interactable = true;
        }
        else
        {
            czysc.interactable = false;
        }

        if (blokada == true)
        {
            rozp.interactable = false;
        }
        else
        {
                rozp.interactable = true;
        }

        if(TablicaWynikow[0] == 0 || TablicaWynikowNick[0] == "")
            {
                btTaWy.interactable = false;
            }
            else
            {
                btTaWy.interactable = true;
            }
    }
}

    
    [Serializable]
    class Save
    {
        public int refRate;
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
        public string nick;
        public int wynik;
        public int ilZycie;
        public int poziomTr;
    }

}
