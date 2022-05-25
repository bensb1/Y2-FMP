using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject Bomb;
    public GameObject killzone;
    public float speed = 5f;
    public float delay = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var objects = GameObject.FindGameObjectsWithTag("bomb");
        var objectCount = objects.Length;
        foreach (var obj in objects)
        {
            // whatever
            if (obj.name != "bomb_0") { 
            Destroy(obj, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
            //Debug.Log(obj.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            } 
        }

        

        if (Bomb.transform.position.y > -4.44)
        {
            Bomb.transform.Translate(0, -0.11f, speed * Time.deltaTime, -0);
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Spaceship>().Damage();
            Destroy(gameObject);
        }
    }
}




