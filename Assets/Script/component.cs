using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class component : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        go = GameObject.Find("Player");
        if (go == null)
        {
            Debug.Log("Nie Istnieje jeszcze");
        }
        else
        {
           
           CharacterController cc = go.AddComponent(typeof(CharacterController)) as CharacterController;
           
        }
    }
}
