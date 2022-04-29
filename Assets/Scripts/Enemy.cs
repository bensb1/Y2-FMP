using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet, explosion, Extralife;
    public GameObject Blue_bullet, Green_Bullet, Purple_Bullet;
    Rigidbody2D rb;
    public Color bulletcolor;


    public float xSpeed, ySpeed;
    public int score;
    public int coins;
    public bool canShoot;
    public float fireRate;
    public float Health;
    public int Refuel = 5;
    private Fuel fuel;
    private Spaceship spaceship;
    private void Awake()
    {
        fuel = GameObject.Find("FuelBar").GetComponent<Fuel>();
        spaceship = GameObject.Find("Player").GetComponent<Spaceship>();
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
        rb.velocity = new Vector2(xSpeed, ySpeed * -1);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Spaceship>().Damage();
            Die();
        }
    }
    void Die()
    {
        if ((int)Random.Range(0, 3) == 0)
        {
            Instantiate(Extralife, transform.position, Quaternion.identity);
        }
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coins);






        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Refill();

    }
    public void Damage()
    {
  /*      if (spaceship.bullet.gameObject == spaceship.bullet.gameObject)
        {
            Health--;
        }
  */
        if (spaceship.bullet == spaceship.Blue_bullet)
        {


            Health = Health - 2;
            

        }
    

       else if (spaceship.bullet == spaceship.Green_Bullet)
        {

            Health = Health - 4;
            
        }
          else if (spaceship.bullet == spaceship.Purple_Bullet)
        {
            
            Health = Health - 5;
            Debug.Log(Health);
        }
         else
        {
            Health--;
        }


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
    public void Refill()
    {
        fuel.currentFuel = fuel.currentFuel + Refuel;
        fuel.slider.value = fuel.currentFuel;
        if (fuel.currentFuel >= 100)
        {
            fuel.currentFuel = fuel.maxFuel;
            fuel.slider.value = fuel.maxFuel;
        }
    }
}
 