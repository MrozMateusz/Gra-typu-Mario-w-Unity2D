using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traps : MonoBehaviour
{
    private Animator bearTrapAnimator;
    private GameObject bearTrapGameObject;
    private bool startBearTrap = false;
    float timer = 0.0f;
    bool reopenBearTrap;
    bool blok;
    // Start is called before the first frame update

    void Start()
    {
        bearTrapGameObject = GameObject.Find("bearTrap");
        bearTrapAnimator = bearTrapGameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.tag == "Player")
        {
            timer = 0;
            startBearTrap = true;
            reopenBearTrap = false;


        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1.0f)
        {
            startBearTrap = false;
            reopenBearTrap = true;
            blok = false;
            
        }
        bearTrapAnimator.SetBool("bearTrapBool", startBearTrap);

        if (startBearTrap == false && blok==false)
        {

            if (timer > 1.75f)
            {
                blok = true;
                reopenBearTrap = false;
            }
        }
        bearTrapAnimator.SetBool("ReopenBearTrap", reopenBearTrap);
    }
}
