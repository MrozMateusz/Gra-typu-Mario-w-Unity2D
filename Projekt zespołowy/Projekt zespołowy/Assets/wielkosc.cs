using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wielkoscTla : MonoBehaviour
{
    Vector2 zm;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        tr.localScale = new Vector2(Screen.height, Screen.width);

    }
}
