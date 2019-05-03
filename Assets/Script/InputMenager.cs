using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputMenager : MonoBehaviour
{
    [SerializeField]
    public Dictionary<string, KeyCode> klawisze;

    public Text skok1;
    public Text skok2;
    public Text skok3;
    public Text left4;
    public Text left5;
    public Text right6;
    public Text right7;

    private GameObject wybranyklawisz;

    Scene scena;

    // Start is called before the first frame update
    void Start()
    {
        klawisze = new Dictionary<string, KeyCode>();
        scena = SceneManager.GetActiveScene();
       

        if (scena.name == "Menu") {

                if (!klawisze.ContainsKey("Up"))
                {
                    klawisze.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Up", "W")));
                }
                if (!klawisze.ContainsKey("UpAlt"))
                {
                    klawisze.Add("UpAlt", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("UpAlt", "Space")));
                }
                if (!klawisze.ContainsKey("UpAlt2"))
                {
                    klawisze.Add("UpAlt2", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("UpAlt2", "UpArrow")));
                }
                if (!klawisze.ContainsKey("Left"))
                {
                    klawisze.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
                }
                if (!klawisze.ContainsKey("LeftAlt"))
                {
                    klawisze.Add("LeftAlt", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftAlt", "LeftArrow")));
                }
                if (!klawisze.ContainsKey("Right"))
                {
                    klawisze.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
                }
                if (!klawisze.ContainsKey("RightAlt"))
                {
                    klawisze.Add("RightAlt", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightAlt", "RightArrow")));
                }
            
        skok1.text = klawisze["Up"].ToString();
        skok2.text = klawisze["UpAlt"].ToString();
        skok3.text = klawisze["UpAlt2"].ToString();
        left4.text = klawisze["Left"].ToString();
        left5.text = klawisze["LeftAlt"].ToString();
        right6.text = klawisze["Right"].ToString();
        right7.text = klawisze["RightAlt"].ToString();
 
        }
    }

   

    private void OnGUI()
    {
        if(wybranyklawisz != null)
        {
            Event e = Event.current;
            
            if (e.isKey)
            {
                klawisze[wybranyklawisz.name] = e.keyCode;
                wybranyklawisz.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                wybranyklawisz.GetComponent<Image>().color = Color.white;
                wybranyklawisz = null;
            }
        }
    }

    public void ZmienKlawisz(GameObject klikniety)
    {
        if(wybranyklawisz != null)
        {
            wybranyklawisz.GetComponent<Image>().color = Color.white;
        }

        wybranyklawisz = klikniety;
        wybranyklawisz.GetComponent<Image>().color = Color.red;
    }

    public void ZapiszKlawisze()
    {
        foreach(var klaw in klawisze)
        {
            PlayerPrefs.SetString(klaw.Key, klaw.Value.ToString());
            
        }
            PlayerPrefs.Save();
    }

    public void DomyKlaw()
    {

        PlayerPrefs.SetString("Up", "W"); 
        PlayerPrefs.SetString("UpAlt", "Space"); 
        PlayerPrefs.SetString("UpAlt2", "UpArrow"); 
        PlayerPrefs.SetString("Left", "A"); 
        PlayerPrefs.SetString("LeftAlt", "LeftArrow"); 
        PlayerPrefs.SetString("Right", "D"); 
        PlayerPrefs.SetString("RightAlt", "RightArrow");

        skok1.text = "W";
        skok2.text = "Space";
        skok3.text = "UpArrow";
        left4.text = "A";
        left5.text = "LeftArrow";
        right6.text = "D";
        right7.text = "RightArrow";

    }

}
