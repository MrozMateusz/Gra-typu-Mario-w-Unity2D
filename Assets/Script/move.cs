using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    KeyCode Up, UpAlt, UpAlt2, Left, LeftAlt, Right, RightAlt;
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
    public AudioSource skokDz;
    public AudioSource dzwiekBuff;
    public AudioSource FallDz;
    public static bool skoczyl = false;

    // Start is called before the first frame update
    void Start()
    {
        scena = SceneManager.GetActiveScene();
        Animacja = GetComponent<Animator>();
        rig2 = GetComponent<Rigidbody2D>();

        if (PlayerPrefs.HasKey("Up"))
            Up = (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Up"));
        if (PlayerPrefs.HasKey("UpAlt"))
            UpAlt = (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("UpAlt"));
        if (PlayerPrefs.HasKey("UpAlt2"))
            UpAlt2 = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("UpAlt2"));
        if (PlayerPrefs.HasKey("Left"))
            Left = (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Left"));
        if (PlayerPrefs.HasKey("LeftAlt"))
            LeftAlt = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftAlt"));
        if (PlayerPrefs.HasKey("Right"))
            Right = (KeyCode)System.Enum.Parse(typeof(KeyCode),PlayerPrefs.GetString("Right"));
        if (PlayerPrefs.HasKey("RightAlt"))
            RightAlt = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightAlt"));
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
            if (Czas_stop_koniec.czas_zatrzym_koniec == false)
            {

                if (Win.czas_zatrzym == false)
                {
                    DotykaZiemii = Physics2D.OverlapCircle(ziemia.position, rozmiarZiemii, LayerZiemii);
                    //float Horizontal = Input.GetAxis("Horizontal");

                    if (Input.GetKey(Right) || Input.GetKey(RightAlt))
                    {
                        rig2.velocity = new Vector2(1 * predkosc, rig2.velocity.y);
                        transform.localScale = new Vector2(0.8372915f, 0.6437907f);
                    }
                    else if (Input.GetKey(Left) || Input.GetKey(LeftAlt))
                    {
                        rig2.velocity = new Vector2(-1 * predkosc, rig2.velocity.y);
                        transform.localScale = new Vector2(-0.8372915f, 0.6437907f);
                    }
                    else
                    {
                        rig2.velocity = new Vector2(0, rig2.velocity.y);
                    }
                    if (Czas_stop.blok_skok == false)
                    {
                        if ((Input.GetKeyDown(Up) || Input.GetKeyDown(UpAlt) || Input.GetKeyDown(UpAlt2)) && DotykaZiemii)
                        {
                            rig2.velocity = new Vector2(rig2.velocity.x, skok);

                            skokDz.Play();

                            skoczyl = true;

                        }
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
        if(skoczyl == true)
        {
            if(collision.tag == "Ziemia")
            {
                FallDz.Play();
                skoczyl = false;
            }
        }

        if (collision.tag == "Buff")
        {
            skok = 8;
            timer = 0.0f;
            bufsIm.SetActive(true);
            dzwiekBuff.Play();

        }
    }


}

