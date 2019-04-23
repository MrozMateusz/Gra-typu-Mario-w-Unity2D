using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class punktacja : MonoBehaviour
{
    static public int wynik;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        wynik = PlayerPrefs.GetInt("Wynik");
        //this.GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        text.text = wynik.ToString();

        PlayerPrefs.SetInt("Wynik", wynik);
    }

}
