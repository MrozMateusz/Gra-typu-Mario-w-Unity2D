using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OdsPom : MonoBehaviour
{
    KeyCode UpW, UpAltW, UpAlt2W, LeftW, LeftAltW, RightW, RightAltW, ESCW, F1W;

    public Text skok1;
    public Text skok2;
    public Text skok3;
    public Text left4;
    public Text left5;
    public Text right6;
    public Text right7;
    public Text ESC;
    public Text F1;
    public Text ESCPocz;
    public Text F1Pocz;

    Scene scena;
    // Start is called before the first frame update
    void Start()
    {
        scena = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
            if (PlayerPrefs.HasKey("Up"))
                UpW = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up"));
            if (PlayerPrefs.HasKey("UpAlt"))
                UpAltW = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("UpAlt"));
            if (PlayerPrefs.HasKey("UpAlt2"))
                UpAlt2W = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("UpAlt2"));
            if (PlayerPrefs.HasKey("Left"))
                LeftW = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left"));
            if (PlayerPrefs.HasKey("LeftAlt"))
                LeftAltW = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftAlt"));
            if (PlayerPrefs.HasKey("Right"))
                RightW = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right"));
            if (PlayerPrefs.HasKey("RightAlt"))
                RightAltW = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightAlt"));
            if (PlayerPrefs.HasKey("ESC"))
                ESCW = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("ESC"));
            if (PlayerPrefs.HasKey("F1"))
                F1W = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("F1"));


            skok1.text = UpW.ToString();
            skok2.text = UpAltW.ToString();
            skok3.text = UpAlt2W.ToString();
            left4.text = LeftW.ToString();
            left5.text = LeftAltW.ToString();
            right6.text = RightW.ToString();
            right7.text = RightAltW.ToString();
            ESC.text = ESCW.ToString();
            F1.text = F1W.ToString();
        if (scena.name != "Menu")
        {
            ESCPocz.text = ESCW.ToString() + ".";
            F1Pocz.text = F1W.ToString() + ".";
        }
   } 
}
