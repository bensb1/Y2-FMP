using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
   
     public Slider slider;
    public int maxHealth = 1000;
    private float currentHealth;
    public GameObject[] bossChild;
    public Transform[] spawnPoints;
    public float MovementSpeed = 10f;
    private Rigidbody2D enemy;
    public bool changeDirection = false;
    public GameObject bomb;
    
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();
        
        SpawnPoints();
       
    }
    public void Damage()
    {
        
        currentHealth = currentHealth - 0.5f;
        slider.value = currentHealth;
        Debug.Log(slider.value);

    }
    public void SpawnPoints()
    {
        if(currentHealth <= 500)
        {
            
         //   bossChild.Length.GetType(gameObject.SetActive(true));
          //  Instantiate(bossChild, bossChild.transform.position, Quaternion.identity);
        }
    }
    public void enemyMovement()
    {
        if (changeDirection == true)
        {
            enemy.velocity = new Vector2(1, 0) * -1 * MovementSpeed;
        }
        else if (changeDirection == false)
        {
            enemy.velocity = new Vector2(1, 0) * MovementSpeed;
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "RightWall")
        {
            Debug.Log("Hit the RightWall");
            changeDirection = true;
        }
        if(col.gameObject.name == "LeftWall")
        {
            Debug.Log("Hit the LeftWall");
            changeDirection = false;
        }
    }
    public void enemyAttacks()
    {
        Instantiate(bomb, bomb.transform.position, Quaternion.identity);
    } 
}
