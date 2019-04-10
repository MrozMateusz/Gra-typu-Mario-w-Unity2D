using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punktacja : MonoBehaviour
{
    static public int wynik;

    // Start is called before the first frame update
    void Start()
    {
        wynik = PlayerPrefs.GetInt("Wynik");
        this.GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMesh>().text = wynik.ToString();

        PlayerPrefs.SetInt("Wynik", wynik);
    }

}
