using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TablicaWynikowMenu : MonoBehaviour
{
    public Text tekstWynikowtab;
    int[] TablicaWynikow = new int[10];
    string[] TablicaWynikowNick = new string[10];

    // Start is called before the first frame update
    void Start()
    {
        TablicaWynikow = PlayerPrefsX.GetIntArray("TablicaWynikow");
        TablicaWynikowNick = PlayerPrefsX.GetStringArray("TablicaWynikowNick");

        if (TablicaWynikow[0] == 0 || TablicaWynikowNick[0] == "")
        {
            tekstWynikowtab.text = "Brak Wyników!";
        }
        else
        {
            tekstWynikowtab.text = "";
            for (int i = 0; TablicaWynikow[i] != 0; i++)
            {
                for (int j = 0; TablicaWynikowNick[j] != ""; j++)
                {
                    tekstWynikowtab.text += (i + 1) + " . " + TablicaWynikowNick[j] + " . " + TablicaWynikow[i] + " Pkt." + System.Environment.NewLine;
                    if ( j == 9)
                    {
                        break;
                    }

                }
                    if (i == 9)
                    {
                        break;
                    }
            }
        }
    }
}

