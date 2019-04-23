using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zmianaCheckpointa : MonoBehaviour
{

    public Sprite czerownaFlaga;
    public Sprite zielonaFlaga;
    private SpriteRenderer flaga;
    public static bool zmienione = false;
    // Start is called before the first frame update
    void Start()
    {
        flaga = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.tag == "Player")
        {
            flaga.sprite = zielonaFlaga;
            zmienione = true;
        }
    }
    
}
