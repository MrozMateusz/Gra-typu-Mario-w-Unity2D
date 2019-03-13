using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Przesuwanie : MonoBehaviour
{
    public float predkoscprzewijania;
    private Vector2 offset;

    void Update()
    {
        offset = new Vector2(Time.time * predkoscprzewijania,0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }

}
