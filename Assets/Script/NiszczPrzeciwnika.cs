/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiszczPrzeciwnika : MonoBehaviour
{
    public bool zniszcz = false;

    public float odlegPromienia;

    RaycastHit2D RayCast;
    Vector3 pozycja;
    Vector3 velocity;
    static public float odbijanie;
    public LayerMask podlogaMaska;

    Ray traf;
 

    public GameObject Objekt;

    void SprawdzKolizje()
    {
        Vector2 poz = new Vector2(pozycja.x, pozycja.y - 1f);

        RayCast = Physics2D.Raycast(poz, Vector2.down, velocity.y * Time.deltaTime, podlogaMaska);

        if (RayCast.collider != null)
        {
            RaycastHit2D RayCast2 = RayCast;


            if (RayCast2.collider.tag == "Enemy")
            {
                RayCast2.collider.GetComponent<EnemyScript>().Zniszcz();
                zniszcz = true;
            }
        }
    }
}*/
