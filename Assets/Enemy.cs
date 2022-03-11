using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet,explosion,Extralife;
   //  public GameObject Blue_bullet,Green_Bullet,Purple_Bullet;
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
         //Blue_bullet.SetActive(false);
      //  Green_Bullet.SetActive(false);
      //  Purple_Bullet.SetActive(false);
        
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
      /*  Blue_bullet.SetActive(true);
        if (Blue_bullet.gameObject == true)
        {
            Green_Bullet.SetActive(false);
            Purple_Bullet.SetActive(false);
            Health =- 3;
        }
       
        else if (Green_Bullet.gameObject == true)
        {
            Blue_bullet.SetActive(false);
            Green_Bullet.SetActive(true);
            Health = -4;
        }
       else if (Purple_Bullet.gameObject ==true)
        {
            Blue_bullet.SetActive(false);
            Green_Bullet.SetActive(false);
            Purple_Bullet.SetActive(true);
            Health = - 5;
        }

        if (Health == 0)
        {
            Die();
        }
      */
    }
    void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
        temp.GetComponent<Bullet>().ChangeColor(bulletcolor);
    }
}
 