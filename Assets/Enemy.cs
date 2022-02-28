using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

   public float xSpeed;
    public float ySpeed;
    public bool canShoot;
    public float fireRate;
    public float Health;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed,ySpeed*-1);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Spaceship>().Damage();
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
   public void Damage()
    {
        Health--;
        if (Health == 0)
        {
            Die();
        }
    }
}
