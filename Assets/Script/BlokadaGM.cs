using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlokadaGM : MonoBehaviour
{

    public GameObject Gm;

    private void Awake()
    {
            DontDestroyOnLoad(Gm);
        
    }

 
}
