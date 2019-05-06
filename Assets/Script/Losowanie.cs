using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Losowanie : MonoBehaviour
{
    int rand;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 400);

        if(rand < 200 && rand%9 != 0)
        {
            this.gameObject.SetActive(false);
        }
       
        Debug.Log(rand);
    }

}
