using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NowyPoztrload : MonoBehaviour
{
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 4)
        {
            if (PlayerPrefs.GetInt("PoziomTrOstUkon") == 1)
            {
                SceneManager.LoadScene(1);
                PlayerPrefs.SetFloat("PozX", -10.77f);
                PlayerPrefs.SetFloat("PozY", -2.86f);
                PlayerPrefs.SetFloat("PozZ", 13.6342f);
                PlayerPrefs.SetInt("Wynik", 0);
                PlayerPrefs.SetInt("ILZY", 2);
                PlayerPrefs.SetInt("PoziomTr", 2);
                PlayerPrefs.GetString("NicK");
            }
            else if(PlayerPrefs.GetInt("PoziomTrOstUkon") == 2)
            {
                SceneManager.LoadScene(1);
                PlayerPrefs.SetFloat("PozX", -10.77f);
                PlayerPrefs.SetFloat("PozY", -2.86f);
                PlayerPrefs.SetFloat("PozZ", 13.6342f);
                PlayerPrefs.SetInt("Wynik", 0);
                PlayerPrefs.SetInt("ILZY", 4);
                PlayerPrefs.SetInt("PoziomTr", 3);
                PlayerPrefs.GetString("NicK");
            }

        }

    }
}
