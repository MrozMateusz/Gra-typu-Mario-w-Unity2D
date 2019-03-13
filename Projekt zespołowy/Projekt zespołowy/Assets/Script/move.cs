using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    private Rigidbody2D rig2;
    float skok = 5;
    float predkosc = 3;
    Scene scena;
    public Transform ziemia;
    public float rozmiarZiemii;
    public LayerMask LayerZiemii;
    private bool DotykaZiemii;
    private Animator Animacja;
    readonly string naz="Menu";
    int licznikSkokow = 0;
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

       if (scena.name == naz)
        {
            Debug.Log("Zla scena. Poruszanie wylaczone!");
        }else{
            klaw();
        }
    }

    private void klaw()
    {
        DotykaZiemii = Physics2D.OverlapCircle(ziemia.position, rozmiarZiemii, LayerZiemii);
        float Horizontal = Input.GetAxis("Horizontal");
        
        if(Horizontal > 0f)
        {
            rig2.velocity = new Vector2(Horizontal * predkosc, rig2.velocity.y);
            transform.localScale = new Vector2(1.211507f, 1.1119f);
        }
        else if(Horizontal < 0f)
        {
            rig2.velocity = new Vector2(Horizontal * predkosc, rig2.velocity.y);
            transform.localScale = new Vector2(-1.211507f, 1.1119f);
        }
        else
        {
            rig2.velocity = new Vector2(0, rig2.velocity.y);
        }

        if (Input.GetButtonDown("Jump")||Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && DotykaZiemii)
        {
            rig2.velocity = new Vector2(rig2.velocity.x, skok);
            licznikSkokow= licznikSkokow + 1;
        }


        Animacja.SetFloat("Predkosc", Mathf.Abs(rig2.velocity.x));
        Animacja.SetBool("NaZiemii", !DotykaZiemii);
    }

    
}

