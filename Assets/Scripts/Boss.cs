using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
   
     public Slider slider;
    public int maxHealth = 700;
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
    public GameObject boss;
    private bool isCreated;
   

    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    //    boss = GetComponent<GameObject>();
      
      
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





         switch (currentHealth)
          {
            //case int n when(n >= 100):
            case float currentHealth when (currentHealth >= 700):
                  spriteRenderer.sprite = sprites[0];
                break;

            case float currentHealth when (currentHealth >= 600):
                spriteRenderer.sprite = sprites[1];

                break;

            case float currentHealth when (currentHealth >= 500):
                spriteRenderer.sprite = sprites[2];
                if (gameObject.name != "Boss(Clone)")
                {


                    if (!isCreated)
                    {
                        Instantiate(boss, spawnPoints[0].transform.position, Quaternion.identity);
                        Instantiate(boss, spawnPoints[1].transform.position, Quaternion.identity);
                        //   Instantiate(boss, spawnPoints[2].transform.position, Quaternion.identity);
                        isCreated = true;
                    }
                }
                break;
              case float currentHealth when (currentHealth >= 450):
                spriteRenderer.sprite = sprites[3];
                break;
            case float currentHealth when (currentHealth >= 350):
                spriteRenderer.sprite = sprites[4];
                break;
            case float currentHealth when (currentHealth >= 300):
                spriteRenderer.sprite = sprites[5];
                break;
            case float currentHealth when (currentHealth >= 200):
                spriteRenderer.sprite = sprites[6];
                break;
            case float currentHealth when (currentHealth >= 150):
                spriteRenderer.sprite = sprites[7];
                break;
            case float currentHealth when (currentHealth >= 10):
                spriteRenderer.sprite = sprites[8];
                break;
            case float currentHealth when (currentHealth >= 1):
                spriteRenderer.sprite = sprites[9];
                break;
            case float currentHealth when (currentHealth <= 0):
                Destroy(this);
                break;

            default:
                spriteRenderer.sprite = sprites[0];

                break;
          } 
    }
}
