using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    CharacterController Cont;
    Transform trans;
    // Start is called before the first frame update
    void Start()
    {
        Cont = GetComponent<CharacterController>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {


        
    }
}
