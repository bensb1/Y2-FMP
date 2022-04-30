using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject Bomb;
    public GameObject killzone;
    public float speed = 5f;
    public float delay = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(GameObject.Find("bomb_0(Clone)"), this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);

        if (Bomb.transform.position.y > -4.44)
        {
            Bomb.transform.Translate(0, -0.01f, speed * Time.deltaTime, -0);
        }
    }
    
   
    }

