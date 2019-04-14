using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TablicaWynikowMenu : MonoBehaviour
{
    public Text tekstWynikowtab;
    int[] TablicaWynikow = new int[10];

    // Start is called before the first frame update
    void Start()
    {
        TablicaWynikow = PlayerPrefsX.GetIntArray("TablicaWynikow");
        if(TablicaWynikow[0] == 0)
        {
            tekstWynikowtab.text = "Brak Wyników!";
        }
        else
        {
            tekstWynikowtab.text = "";
            for(int i = 0; TablicaWynikow[i] !=0; i++)
            {
                tekstWynikowtab.text += (i + 1) + "." + TablicaWynikow[i] + "Pkt." + System.Environment.NewLine;  
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
