using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThings : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("kolizja z playerem");
            Destroy(this.gameObject);
        }

    }

}
