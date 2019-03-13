using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zmianaCheckpointa : MonoBehaviour
{

    public Sprite czerownaFlaga;
    public Sprite zielonaFlaga;
    private SpriteRenderer zmiana;
    public bool zmienione;
    // Start is called before the first frame update
    void Start()
    {
        zmiana = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.tag == "Player")
        {
            zmiana.sprite = zielonaFlaga;
            zmienione = true;
        }
    }
    
}
