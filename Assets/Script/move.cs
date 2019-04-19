using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    private Rigidbody2D rig2;
    float skok = 5;
    float predkosc = 3;
    static public bool zranienie = false;

    Scene scena;
    public Transform ziemia;
    public float rozmiarZiemii;
    public LayerMask LayerZiemii;
    private bool DotykaZiemii;
    private Animator Animacja;
    public GameObject bufsIm;
    readonly string naz="Menu";
    float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        scena = SceneManager.GetActiveScene();
        Animacja = GetComponent<Animator>();
        rig2 = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

       if (scena.name == naz)
        {
            Debug.Log("Zla scena. Poruszanie wylaczone!");
        }else{
            klaw();
        }

        if (timer > 6.0f)
        {
            skok = 5;
            bufsIm.SetActive(false);
        }

        if (PlayerPrefs.GetInt("Zran") == 1)
        {
            zranienie = true;
        }
        else
        {
            zranienie = false;
        }
    }

    private void klaw()
    {
        if (zranienie == false)
        {
            if (Time.timeScale != 0.0f)
            {
                DotykaZiemii = Physics2D.OverlapCircle(ziemia.position, rozmiarZiemii, LayerZiemii);
                float Horizontal = Input.GetAxis("Horizontal");

                if (Horizontal > 0f)
                {
                    rig2.velocity = new Vector2(Horizontal * predkosc, rig2.velocity.y);
                    transform.localScale = new Vector2(0.8372915f, 0.6437907f);
                }
                else if (Horizontal < 0f)
                {
                    rig2.velocity = new Vector2(Horizontal * predkosc, rig2.velocity.y);
                    transform.localScale = new Vector2(-0.8372915f, 0.6437907f);
                }
                else
                {
                    rig2.velocity = new Vector2(0, rig2.velocity.y);
                }

                if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && DotykaZiemii)
                {
                    rig2.velocity = new Vector2(rig2.velocity.x, skok);
                }
            }
            else
            {
                rig2.velocity = new Vector2(0, rig2.velocity.y);
            }
        }
        else
        {
            rig2.velocity = new Vector2(0, rig2.velocity.y);
        }
        Animacja.SetFloat("Predkosc", Mathf.Abs(rig2.velocity.x));
        Animacja.SetBool("NaZiemii", !DotykaZiemii);
        Animacja.SetBool("Zranienie", zranienie);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Buff")
        {
            skok = 8;
            timer = 0.0f;
            bufsIm.SetActive(true);
        }
    }


}

