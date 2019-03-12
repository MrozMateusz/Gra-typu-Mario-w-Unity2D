using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{
    public CharacterController Cont;
    float skok = 5;
    float predkosc = 3;
    float aktualna_wyskosc = 0.0f;
    Scene scena;
    readonly string naz="Menu";
    // Start is called before the first frame update
    void Start()
    {
        scena = SceneManager.GetActiveScene();
        
        //  Cont = GetComponent<CharacterController>();
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

        float Horizontal = Input.GetAxis("Horizontal") * predkosc;
        

        if (Cont.isGrounded && Input.GetButton("2dskok"))
        {
            aktualna_wyskosc = skok;
        }
        else if (!Cont.isGrounded)
        {
            aktualna_wyskosc += Physics.gravity.y * Time.deltaTime;
        }
       
        Vector2 ruch = new Vector2(Horizontal, aktualna_wyskosc);
        ruch = transform.rotation * ruch;

        Cont.Move(ruch * Time.deltaTime);
    }

    
}

