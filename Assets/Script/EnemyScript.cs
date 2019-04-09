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
    private Rigidbody2D enemyRigidBody;

    float predkosc = 2;
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
        enemyRigidBody = this.GetComponent<Rigidbody2D>();
        gm = GameObject.FindGameObjectsWithTag("Enemy");
        predkosc = predkosc * Time.deltaTime;
        foreach (GameObject mg in gm) { //chyba niepotrzebne 
            rig2d = mg.GetComponent<Rigidbody2D>();
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
            enemyRigidBody.velocity = new Vector2(1, 1);
            this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, this.transform.position.y, this.transform.position.z), predkosc * Time.deltaTime);

        }
        else
        {
            if (zmiana == true)
            {
                enemyRigidBody.velocity = new Vector2(predkosc, enemyRigidBody.velocity.y);
                this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);

            }
            else
            {
                enemyRigidBody.velocity = new Vector2(-predkosc, -enemyRigidBody.velocity.y);
                this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);

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
