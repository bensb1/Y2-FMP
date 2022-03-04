using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 15f ;
    public bool changeDirection = false;
    public GameObject bullet,explosion,Extralife;
    Rigidbody2D rb;
    public Color bulletcolor;

   public float xSpeed,ySpeed;
    public int score;
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
        
        if (!canShoot) return;
        {
            fireRate = fireRate + (Random.Range(fireRate / -2, fireRate / 2));
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed,ySpeed*-1);
        moveEnemy();
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "RightWall")
        {
            Debug.Log("Hit the Right Wall");
            changeDirection = true;
        }
        if (col.gameObject.name == "LeftWall")
        {
            Debug.Log("Hit the Left Wall");
            changeDirection = false;
        }
       
            if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Spaceship>().Damage();
            Die();
        }
    }
    void Die()
    {
        if( (int)Random.Range(0,3)==0)
        {
            Instantiate(Extralife, transform.position, Quaternion.identity);
        }
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        Instantiate(explosion, transform.position, Quaternion.identity);
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
    void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
        temp.GetComponent<Bullet>().ChangeColor(bulletcolor);
    }
     public void moveEnemy()
    {
        
        if(changeDirection == true)
        {
            rb.velocity = new Vector2(1, 0) * -1 * moveSpeed;
        }
        
        else if (changeDirection == false)
        {
            rb.velocity = new Vector2(1, -1) * moveSpeed;
        }
        
    }
   
}
