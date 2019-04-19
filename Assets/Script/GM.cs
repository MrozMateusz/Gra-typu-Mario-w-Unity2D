using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{

    public static GM GameMen;
   
    private void Awake()
    {

        if (GameMen == null)
        {
            DontDestroyOnLoad(gameObject);
        }else if(GameMen != this)
        {
            Destroy(gameObject);
        }

    }

 
}
