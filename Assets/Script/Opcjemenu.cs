using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Opcjemenu : MonoBehaviour
{

    public Toggle FullScreen;
    public Dropdown rozdzielczosc;
    public Slider glosnosc;
    private Resolution[] rozdzielczosci;
    private bool fs;

    // Start is called before the first frame update
    void Start()
    {
        
        rozdzielczosci = Screen.resolutions;

        FullScreen.isOn = Screen.fullScreen;
        glosnosc.value = AudioListener.volume;

        glosnosc.onValueChanged.AddListener(delegate { GlosnoscZmiana(); });
        FullScreen.onValueChanged.AddListener(delegate { FullScreenZmiana(); });
        rozdzielczosc.onValueChanged.AddListener(delegate { RozdzielczoscZmiana(); });

    }

    private void FixedUpdate()
    {


        rozdzielczosc.options.Clear();
        for (int i = 0; i < rozdzielczosci.Length; i++)
        {

                rozdzielczosc.options.Add(new Dropdown.OptionData());
                rozdzielczosc.options[i].text = RoztoString(rozdzielczosci[i]);
                
                if (RoztoString(rozdzielczosci[i]) == (Screen.width + "x" + Screen.height))
                {
                    rozdzielczosc.value = i;
                }
            
        }
        rozdzielczosc.RefreshShownValue();
        fs = Screen.fullScreen;

        if (fs == true)
        {
            FullScreen.isOn = true;
        }
        else
        {
            FullScreen.isOn = false;
        }
        glosnosc.value = AudioListener.volume;

    }
    public void FullScreenZmiana()
    {
        if (FullScreen.isOn)
        {
            Screen.fullScreen = true;
        }
        else
        {
            Screen.fullScreen = false;
        }
    }
    public void GlosnoscZmiana()
    {
        AudioListener.volume = glosnosc.value;
    }

    public void RozdzielczoscZmiana()
    {
        Screen.SetResolution(int.Parse(StringToRoz(rozdzielczosc.options[rozdzielczosc.value].text)[0]), int.Parse(StringToRoz(rozdzielczosc.options[rozdzielczosc.value].text)[1]), FullScreen.isOn);
    }


    string[] StringToRoz(string roz)
    {
        return roz.Split('x');
    }

    string RoztoString(Resolution roz)
        {
            return roz.width + "x" + roz.height;
        }
}
