using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlokadaGmaster : MonoBehaviour
{

    public GameObject Gmm;
    Scene scena;

   
    // Start is called before the first frame update
    void Start()
    {
        scena = SceneManager.GetActiveScene();
     
        DontDestroyOnLoad(Gmm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
