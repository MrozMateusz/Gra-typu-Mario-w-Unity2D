using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoniecGry : MonoBehaviour
{
    public Text wynikLicz;
    public Text czasLicz;

    private int wynik;
    private int[] TablicaWynikow = new int[10]; 
    // Start is called before the first frame update
    void Start()
    {

        wynikLicz.text = punktacja.wynik.ToString();
        czasLicz.text = CzasGry.CzasR;



        TablicaWynikow = PlayerPrefsX.GetIntArray("TablicaWynikow");

        wynik = int.Parse(wynikLicz.text);
        if (wynik > TablicaWynikow[9])
        {
            for(int i = 0; i<10; i++)
            {
                if (wynik > TablicaWynikow[i])
                {
                    for(int j = 9; j>i; j--)
                    {
                        TablicaWynikow[j] = TablicaWynikow[j - 1];
                    }
                    TablicaWynikow[i] = wynik;
                    break;
                }
            }

        }
        PlayerPrefsX.SetIntArray("TablicaWynikow", TablicaWynikow);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
