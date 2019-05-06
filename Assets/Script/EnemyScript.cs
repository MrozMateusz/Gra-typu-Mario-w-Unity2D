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
    readonly string naz = "Menu";
    bool zmiana=true;
    static public bool zniszcz = false;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject mg in gm)
            {
                rig2d = GetComponent<Rigidbody2D>();
            }
            if(gm == null)
            {
                Debug.Log("koniec przeciwników");
            }

        if (PlayerPrefs.GetInt("PoziomTr") == 1)
        {
            predkosc = 3;
        }
        else if (PlayerPrefs.GetInt("PoziomTr") == 2)
        {
            predkosc = 5;
        }
        else if (PlayerPrefs.GetInt("PoziomTr") == 3)
        {
            predkosc = 6.8f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerPrefs.GetInt("PoziomTr") == 3)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            punktStartowy = GameObject.FindGameObjectWithTag("Start").GetComponent<Transform>();
            punktKoncowy = GameObject.FindGameObjectWithTag("End").GetComponent<Transform>();
        }
            scena = SceneManager.GetActiveScene();

            zniszcz = false;
            if (scena.name == naz)
            {
                Debug.Log("Zla scena. Poruszanie wylaczone!");
            }
            else
            {
            if (PlayerPrefs.GetInt("PoziomTr") != 3)
            {
                foreach (GameObject mg in gm)
                {
                   ruch_przec();
                }

            }
            else
            {
                foreach (GameObject mg in gm)
                {
                    ruch_przec_P3();
                }
            }
        }
        
    }

    void ruch_przec()
    {
        if (move.zranienie == false)
        {
            //(Vector2.Distance(this.transform.position, player.position) < 5) && (this.transform.position.x > punktStartowy.position.x) && (this.transform.position.x < punktKoncowy.position.x)
            /* if (isBetween(player, punktStartowy, punktKoncowy) && (isBetween(this.transform, punktStartowy, punktKoncowy))){ //podążanie przeciwników za playerem
                 this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, this.transform.position.y, this.transform.position.z), predkosc * Time.deltaTime);
             }
             else*/
            float x = this.transform.localScale.x;

            if (zmiana == true)
                {
                    
                    if(x>0) x = -x;
                    rig2d.velocity = new Vector2(predkosc, rig2d.velocity.y);
                    this.transform.localScale = new Vector3(x, this.transform.localScale.y, 1f);

                }
                else
                {
                if (x < 0) x = -x;
                rig2d.velocity = new Vector2(-predkosc, -rig2d.velocity.y);
                    this.transform.localScale = new Vector3(x, this.transform.localScale.y, 1f);

                }
 
        }
        else
        {
            rig2d.velocity = new Vector2(0, rig2d.velocity.y);
        }

    }

    void ruch_przec_P3()
    {
        if (move.zranienie == false)
        {
            //(Vector2.Distance(this.transform.position, player.position) < 5) && (this.transform.position.x > punktStartowy.position.x) && (this.transform.position.x < punktKoncowy.position.x)
            if (isBetween(player, punktStartowy, punktKoncowy) && (isBetween(this.transform, punktStartowy, punktKoncowy))) { //podążanie przeciwników za playerem
                this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, this.transform.position.y, this.transform.position.z), predkosc/2 * Time.deltaTime);
            }
            else
            {

                if (zmiana == true)
                {
                    rig2d.velocity = new Vector2(predkosc, rig2d.velocity.y);
                    this.transform.localScale = new Vector3(-0.5791352f, 0.567311f, 1f);

                }
                else
                {
                    rig2d.velocity = new Vector2(-predkosc, -rig2d.velocity.y);
                    this.transform.localScale = new Vector3(0.5791352f, 0.567311f, 1f);

                }
            }
        }
        else
        {
            rig2d.velocity = new Vector2(0, rig2d.velocity.y);
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
        if (gm != null)
        {
            if (scena.name == naz)
            {
                Debug.Log("Zla scena. Poruszanie wylaczone!");
            }
            else
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
            if (kolizja.tag == "Player")
            {
                Destroy(this.gameObject);
                zniszcz = true;
                if (PlayerPrefs.GetInt("PoziomTr") == 1)
                {
                    punktacja.wynik++;
                }
                else if (PlayerPrefs.GetInt("PoziomTr") == 2)
                {
                    punktacja.wynik = punktacja.wynik + 2;
                }
                else if (PlayerPrefs.GetInt("PoziomTr") == 3)
                {
                    punktacja.wynik = punktacja.wynik + 3;
                }
            }


        }
    }
}
