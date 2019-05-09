using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zycie : MonoBehaviour
{
    static public int zycie = 3;
    public GameObject kon;
    public int mozKon = 1;
    public Text text;
    public static bool blokada = false;

    // Start is called before the first frame update
    void Start()
    {
        zycie = PlayerPrefs.GetInt("ILZY");

    }

    // Update is called once per frame
    void Update()
    {
        text.text = zycie.ToString();

        PlayerPrefs.SetInt("ILZY", zycie);

        if (punktacja.wynik % 10 == 0 && blokada == false && punktacja.wynik != 0 && PlayerPrefs.GetInt("PoziomTr") != 3)
        {
            zycie += 1;
            blokada = true;
        }

        if (PlayerPrefs.GetInt("PoziomTr") == 3)
        {

            if((punktacja.wynik - 2) % 10 == 0 && blokada == false && punktacja.wynik != 0)
            {
                zycie += 1;
                blokada = true;
            }
            if ((punktacja.wynik - 1) % 10 == 0 && blokada == false && punktacja.wynik != 0)
            {
                zycie += 1;
                blokada = true;
            }
            if (punktacja.wynik % 10 == 0 && blokada == false && punktacja.wynik != 0)
            {
                zycie += 1;
                blokada = true;
            }

        }

        if (zycie < 1)
        {
            kon.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0.0f;
            mozKon = 0;
            PlayerPrefs.SetInt("MozKon", mozKon);

        }
        else
        {
            mozKon = 1;
            PlayerPrefs.SetInt("MozKon", mozKon);
        }
    }
}
