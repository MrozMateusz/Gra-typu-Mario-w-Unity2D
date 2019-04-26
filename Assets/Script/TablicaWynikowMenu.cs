using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TablicaWynikowMenu : MonoBehaviour
{
    public Text tekstWynikowtab0;
    public Text tekstWynikowtab1;
    public Text tekstWynikowtab2;
    public Text tekstWynikowtab3;
    public Text tekstWynikowtab4;
    public Text tekstWynikowtab5;
    public Text tekstWynikowtab6;
    public Text tekstWynikowtab7;
    public Text tekstWynikowtab8;
    public Text tekstWynikowtab9;

    public Text tekstWynikowtabWyn0;
    public Text tekstWynikowtabWyn1;
    public Text tekstWynikowtabWyn2;
    public Text tekstWynikowtabWyn3;
    public Text tekstWynikowtabWyn4;
    public Text tekstWynikowtabWyn5;
    public Text tekstWynikowtabWyn6;
    public Text tekstWynikowtabWyn7;
    public Text tekstWynikowtabWyn8;
    public Text tekstWynikowtabWyn9;

    int[] TablicaWynikow = new int[10];
    string[] TablicaWynikowNick = new string[10];

    private void Start()
    {
        if(MenedzerMenu.wyczyszczony == true)
        {
            tekstWynikowtab0.text = "";
            tekstWynikowtab1.text = "";
            tekstWynikowtab2.text = "";
            tekstWynikowtab3.text = "";
            tekstWynikowtab4.text = "";
            tekstWynikowtab5.text = "";
            tekstWynikowtab6.text = "";
            tekstWynikowtab7.text = "";
            tekstWynikowtab8.text = "";
            tekstWynikowtab9.text = "";

            tekstWynikowtabWyn0.text = "";
            tekstWynikowtabWyn1.text = "";
            tekstWynikowtabWyn2.text = "";
            tekstWynikowtabWyn3.text = "";
            tekstWynikowtabWyn4.text = "";
            tekstWynikowtabWyn5.text = "";
            tekstWynikowtabWyn6.text = "";
            tekstWynikowtabWyn7.text = "";
            tekstWynikowtabWyn8.text = "";
            tekstWynikowtabWyn9.text = "";

        }
    }


    void Update()
    {
        TablicaWynikow = PlayerPrefsX.GetIntArray("TablicaWynikow");
        TablicaWynikowNick = PlayerPrefsX.GetStringArray("TablicaWynikowNick");

       
        tekstWynikowtab0.text = "";

        tekstWynikowtab0.text += "1" + " .                         " + TablicaWynikowNick[0] + " .                    " + System.Environment.NewLine;
        tekstWynikowtab1.text += "2" + " .                         " + TablicaWynikowNick[1] + " .                    " + System.Environment.NewLine;
        tekstWynikowtab2.text += "3" + " .                         " + TablicaWynikowNick[2] + " .                    " + System.Environment.NewLine;
        tekstWynikowtab3.text += "4" + " .                         " + TablicaWynikowNick[3] + " .                    " + System.Environment.NewLine;
        tekstWynikowtab4.text += "5" + " .                         " + TablicaWynikowNick[4] + " .                    " + System.Environment.NewLine;
        tekstWynikowtab5.text += "6" + " .                         " + TablicaWynikowNick[5] + " .                    " + System.Environment.NewLine;
        tekstWynikowtab6.text += "7" + " .                         " + TablicaWynikowNick[6] + " .                    " + System.Environment.NewLine;
        tekstWynikowtab7.text += "8" + " .                         " + TablicaWynikowNick[7] + " .                    " + System.Environment.NewLine;
        tekstWynikowtab8.text += "9" + " .                         " + TablicaWynikowNick[8] + " .                    " + System.Environment.NewLine;
        tekstWynikowtab9.text += "10" + " .                        " + TablicaWynikowNick[9] + " .                    " + System.Environment.NewLine;

        tekstWynikowtabWyn0.text += TablicaWynikow[0] + " Pkt." + System.Environment.NewLine;
        tekstWynikowtabWyn1.text += TablicaWynikow[1] + " Pkt." + System.Environment.NewLine;
        tekstWynikowtabWyn2.text += TablicaWynikow[2] + " Pkt." + System.Environment.NewLine;
        tekstWynikowtabWyn3.text += TablicaWynikow[3] + " Pkt." + System.Environment.NewLine;
        tekstWynikowtabWyn4.text += TablicaWynikow[4] + " Pkt." + System.Environment.NewLine;
        tekstWynikowtabWyn5.text += TablicaWynikow[5] + " Pkt." + System.Environment.NewLine;
        tekstWynikowtabWyn6.text += TablicaWynikow[6] + " Pkt." + System.Environment.NewLine;
        tekstWynikowtabWyn7.text += TablicaWynikow[7] + " Pkt." + System.Environment.NewLine;
        tekstWynikowtabWyn8.text += TablicaWynikow[8] + " Pkt." + System.Environment.NewLine;
        tekstWynikowtabWyn9.text += TablicaWynikow[9] + " Pkt." + System.Environment.NewLine;


        if (TablicaWynikow[0] == 0 || TablicaWynikowNick[0] == "")
        {
            tekstWynikowtab0.text = "";
            tekstWynikowtabWyn0.text = "";
        }
        if (TablicaWynikow[1] == 0 || TablicaWynikowNick[1] == "")
        {
            tekstWynikowtab1.text = "";
            tekstWynikowtabWyn1.text = "";
        }
        if (TablicaWynikow[2] == 0 || TablicaWynikowNick[2] == "")
        {
            tekstWynikowtab2.text = "";
            tekstWynikowtabWyn2.text = "";
        }
        if (TablicaWynikow[3] == 0 || TablicaWynikowNick[3] == "")
        {
            tekstWynikowtab3.text = "";
            tekstWynikowtabWyn3.text = "";
        }
        if (TablicaWynikow[4] == 0 || TablicaWynikowNick[4] == "")
        {
            tekstWynikowtab4.text = "";
            tekstWynikowtabWyn4.text = "";
        }
        if (TablicaWynikow[5] == 0 || TablicaWynikowNick[5] == "")
        {
            tekstWynikowtab5.text = "";
            tekstWynikowtabWyn5.text = "";
        }
        if (TablicaWynikow[6] == 0 || TablicaWynikowNick[6] == "")
        {
            tekstWynikowtab6.text = "";
            tekstWynikowtabWyn6.text = "";
        }
        if (TablicaWynikow[7] == 0 || TablicaWynikowNick[7] == "")
        {
            tekstWynikowtab7.text = "";
            tekstWynikowtabWyn7.text = "";
        }
        if (TablicaWynikow[8] == 0 || TablicaWynikowNick[8] == "")
        {
            tekstWynikowtab8.text = "";
            tekstWynikowtabWyn8.text = "";
        }
        if (TablicaWynikow[9] == 0 || TablicaWynikowNick[9] == "")
        {
            tekstWynikowtab9.text = "";
            tekstWynikowtabWyn9.text = "";
        }
    }

}

