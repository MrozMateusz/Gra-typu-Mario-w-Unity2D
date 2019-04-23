using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obrot : MonoBehaviour
{
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.Rotate(new Vector3(0, Time.deltaTime * 250, 0));   
    }
}
