using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traps : MonoBehaviour
{
    private Animator bearTrapAnimator;
    private GameObject bearTrapGameObject;
    private bool startBearTrap = false;
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
            startBearTrap = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        bearTrapAnimator.SetBool("bearTrapBool", startBearTrap);
    }
}
