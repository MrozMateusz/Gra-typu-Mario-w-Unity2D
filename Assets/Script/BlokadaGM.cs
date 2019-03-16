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

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
