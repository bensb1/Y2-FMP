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
    private GameObject bomb_Postion;
    private float timer = 0f;
    private float waitTimer = 2f;
    public float speed = 5f;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
   

    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
      
      
        bomb_Postion = transform.Find("bomb_postion").gameObject;
    
        enemy = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        enemyMovement();
        enemyAttacks();
        SpawnPoints();
        enemyAnimation();
       
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
             // Instantiate(bossChild, bossChild.position;
        }
    }
    public void enemyMovement()
    {
        if (changeDirection == true)
        {
            enemy.velocity = new Vector2(1 * (-1 * MovementSpeed), 0) ;
        }
        else if (changeDirection == false)
        {
            enemy.velocity = new Vector2(1 * MovementSpeed, 0);
        }

        //enemy.velocity = Vector2.ClampMagnitude(enemy.velocity, MovementSpeed);
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
        if (timer > waitTimer)
        {
            bomb.SetActive(true);
            Instantiate(bomb, bomb_Postion.transform.position, Quaternion.identity);
            
            
            //    (Bombclone)
            timer = 0;
            
            

            
        }
        //  transform.Translate(0, speed * Time.deltaTime, 0);
        
        bomb.transform.Translate(0,-0.01f, speed * Time.deltaTime, -0);
       // Bombclone.transform.Translate(0, speed * Time.deltaTime, 0);

        
      
       


    } 
    public void enemyAnimation()
    {


        if(currentHealth >=900)
        {
            spriteRenderer.sprite = sprites[0];
        }
        else if ( currentHealth >= 800)
        {
            spriteRenderer.sprite = sprites[1];
        }
        else if (currentHealth >=700)
        {
            spriteRenderer.sprite = sprites[2];
        }
        else if (currentHealth >= 600)
        {
            spriteRenderer.sprite = sprites[3];
        }
        else if (currentHealth >= 500)
        {
            spriteRenderer.sprite = sprites[4];

        }
        else if (currentHealth >= 400)
        {
            spriteRenderer.sprite = sprites[5];
        }
        else if (currentHealth >= 300)
        {
            spriteRenderer.sprite = sprites[6];
        }
        else if (currentHealth >= 200)
        {
            spriteRenderer.sprite = sprites[7];
        }
        else if (currentHealth >= 100)
        {
            spriteRenderer.sprite = sprites[8];
        }
        else if (currentHealth >= 1)
        {
            spriteRenderer.sprite = sprites[9];
        }


        /*  switch (currentHealth)
          {
              case currentHealth >= 900:
                  spriteRenderer.sprite.name("Boss")
                  break;

              case BulletType.blue:
                  Blue_bullet.gameObject.SetActive(true);
                  bullet = Blue_bullet;
                  break;

              case BulletType.Green:
                  bullet = Green_Bullet;
                  break;
              case BulletType.purple:
                  bullet = Purple_Bullet;
                  break;

              default:
                  bullet = bullet.gameObject;

                  break;
          } */
    }
}
