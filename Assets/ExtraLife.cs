using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Player")
        {
            col.gameObject.GetComponent<Spaceship>().AddHealth();
            Destroy(gameObject);
        }
    }
}
