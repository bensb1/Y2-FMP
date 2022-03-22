using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{

    public Animator anim;
    private State state = State.idle;
    private enum State { idle, Moving, Jumping, falling, hurt }
    int delay = 0;
    GameObject a, b;
    public GameObject bullet, explosion;
    public GameObject Blue_bullet;
    public GameObject Green_Bullet;
    public GameObject Purple_Bullet;
    // public int bulletType = 1;
     public enum  BulletType { Normal,Green,blue,purple }; 
   public BulletType bulletType = BulletType.Normal;
    Rigidbody2D rb;
    public float speed;
    int health = 3;
    private float timer = 0f;
    private float waitTimer = 2f;
    private Fuel fuelBar;
    private GameObject oxygenTank;
    private void Awake()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
        b = transform.Find("b").gameObject;
    }
    private void Start()
    {

        fuelBar = GameObject.Find("oxygenBar").GetComponent<Fuel>();
        PlayerPrefs.SetInt("Health", health);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        if (timer > waitTimer)
        {
            Debug.Log(timer);
            fuelBar.UseFuel(5);

            timer = 0;
        }
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
        if (timer > waitTimer)
        {
            Debug.Log(timer);
            fuelBar.UseFuel(5);

            timer = 0;
        }
        // anim.SetBool("Moving", true);
        anim.SetInteger("State", (int)state); //sets animation based on enuemrator state */
        if (Input.GetKey(KeyCode.Space) && delay > 10)
        {
            Shoot();


        }

        delay++;
        AnimationState();

    }
    public void Damage()
    {
        StartCoroutine(Blink());
        health--;
        PlayerPrefs.SetInt("Health", health);
        if (health == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
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






         
        
        

        switch (bulletType)
        {
            case BulletType.Normal:
                bullet = bullet.gameObject;
                break;

            case BulletType.blue:
                Blue_bullet.gameObject.SetActive(true);
                bullet = Blue_bullet;
                break;

            case BulletType.Green:
                bullet = Green_Bullet;
                break;
            case BulletType.purple:
                break;
                
            default:
                bullet = bullet.gameObject;

                break;
        }

        Instantiate(bullet, a.transform.position, Quaternion.identity);
        Instantiate(bullet, b.transform.position, Quaternion.identity);


    }

    public void AddHealth()
    {
        health++;
        PlayerPrefs.SetInt("Health", health);
    }
    private void AnimationState()
    {
        if (Mathf.Abs(rb.velocity.x) < .1f)
        {
            state = State.idle;
        }

        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            //Moving
            state = State.Moving;
        }
        else
        {
            state = State.idle;
        }
    }
}
