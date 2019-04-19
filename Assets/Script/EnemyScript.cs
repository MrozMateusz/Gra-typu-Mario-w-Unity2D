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
    }

    // Update is called once per frame
    void Update()
    {

 
       
            //player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            //punktStartowy = GameObject.FindGameObjectWithTag("Start").GetComponent<Transform>();


            //punktKoncowy = GameObject.FindGameObjectWithTag("End").GetComponent<Transform>();
        


            scena = SceneManager.GetActiveScene();

            zniszcz = false;
            if (scena.name == naz)
            {
                Debug.Log("Zla scena. Poruszanie wylaczone!");
            }
            else
            {
                foreach (GameObject mg in gm)
                {
                
                    ruch_przec();
                }
                
            }
        
    }

    void ruch_przec()
    {
        //(Vector2.Distance(this.transform.position, player.position) < 5) && (this.transform.position.x > punktStartowy.position.x) && (this.transform.position.x < punktKoncowy.position.x)
        /* if (isBetween(player, punktStartowy, punktKoncowy) && (isBetween(this.transform, punktStartowy, punktKoncowy))){ //podążanie przeciwników za playerem
             this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, this.transform.position.y, this.transform.position.z), predkosc * Time.deltaTime);
         }
         else*/
        if (move.zranienie == false)
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
        else
        {
            rig2d.velocity = new Vector2(0, rig2d.velocity.y);
        }
       

    }

    /* private bool isBetween(Transform gameObject, Transform positio1, Transform position2)
     {
         if((gameObject.transform.position.x < position2.position.x) && (gameObject.transform.position.x > positio1.position.x))
         {
             return true;
         }

         return false;
     }*/

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
                punktacja.wynik += 1;
            }


        }
    }
}
