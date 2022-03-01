using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    int delay = 0;
    GameObject a,b;
    public GameObject bullet,explosion;
    Rigidbody2D rb;
     public float speed;
    int health = 3;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a =transform.Find("a").gameObject;
        b =transform.Find("b").gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*speed,0));
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical") * speed));
        if (Input.GetKey(KeyCode.Space)&&delay>10)
        {
            Shoot();

            
        }

        delay++;
    }
    public void Damage()
    {
        StartCoroutine(Blink());
        health--;
        if(health ==0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject,0.1f);
        }
        IEnumerator Blink()
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
        }
    }
    void Shoot()
    {
        delay = 0;
        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);
    }
}
