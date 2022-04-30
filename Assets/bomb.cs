using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject Bomb;
    public GameObject killzone;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Bomb.transform.position.y > -4.44)
        {
            Bomb.transform.Translate(0, -0.01f, speed * Time.deltaTime, -0);
        }
    }
    
   
    }

