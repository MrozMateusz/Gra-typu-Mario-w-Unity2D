using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rig2d;
    GameObject[] gm;
    Scene scena;
    private Transform player;
    private Transform punktStartowy;
    private Transform punktKoncowy;

    float predkosc = 3;
   // private Animator Animacja;
    readonly string naz = "Menu";
    bool zmiana=true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        punktStartowy = GameObject.FindGameObjectWithTag("Start").GetComponent<Transform>();
        punktKoncowy = GameObject.FindGameObjectWithTag("End").GetComponent<Transform>();
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
        //(Vector2.Distance(this.transform.position, player.position) < 5) && (this.transform.position.x > punktStartowy.position.x) && (this.transform.position.x < punktKoncowy.position.x)
        if (isBetween(player, punktStartowy, punktKoncowy) && (isBetween(this.transform, punktStartowy, punktKoncowy))){ //podążanie przeciwników za playerem
            this.transform.position = Vector3.MoveTowards(transform.position, player.position, predkosc * Time.deltaTime);
        }
        else
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


    }

    private bool isBetween(Transform gameObject, Transform positio1, Transform position2)
    {
        if((gameObject.transform.position.x < position2.position.x) && (gameObject.transform.position.x > positio1.position.x))
        {
            return true;
        }

        return false;
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
