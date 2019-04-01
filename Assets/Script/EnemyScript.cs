using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rig2d;
    GameObject[] gm;
    Scene scena;

    float predkosc = 3;
   // private Animator Animacja;
    readonly string naz = "Menu";
    bool zmiana=true;

    // Start is called before the first frame update
    void Start()
    {
        scena = SceneManager.GetActiveScene();
        gm = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject mg in gm) {
            rig2d = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scena.name == naz)
        {
            Debug.Log("Zla scena. Poruszanie wylaczone!");
        }
        else
        {
            foreach (GameObject mg in gm) {
                ruch_przec();
            }
        }
    }

    void ruch_przec()
    {
        if (zmiana == true)
        {
            rig2d.velocity = new Vector2(predkosc, rig2d.velocity.y);
           
        }
        else
        {
            rig2d.velocity = new Vector2(-predkosc, -rig2d.velocity.y);
          
        }
    }

    private void OnTriggerEnter2D(Collider2D kolizja)
    {
        if (kolizja.tag == "Start")
        {
            zmiana = true;
        }
        if (kolizja.tag == "End")
        {
            zmiana = false;
        }
    }
}
