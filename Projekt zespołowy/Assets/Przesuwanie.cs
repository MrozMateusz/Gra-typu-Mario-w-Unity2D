using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przesuwanie : MonoBehaviour
{
    public float predkoscprzewijania;
    private Vector2 offset;

    void Update()
    {
        offset = new Vector2(0,Time.time * predkoscprzewijania);
       // GetComponent<CanvasRenderer>().material.mainTextureOffset = offset;
    }

}
