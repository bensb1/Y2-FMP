using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{

    public Animator anim;
    private State state = State.idle;
    private enum State { idle,Moving,Jumping,falling, hurt}
    int delay = 0;
    GameObject a,b;
    public GameObject bullet,explosion;
    public GameObject Blue_bullet;
    Rigidbody2D rb;
     public float speed;
    int health = 3;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        a =transform.Find("a").gameObject;
        b =transform.Find("b").gameObject;
    }
    private void Start()
    {
        
        PlayerPrefs.SetInt("Health", health);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*speed,0));
        rb.AddForce(new Vector2(0,Input.GetAxis("Vertical") * speed));
        // anim.SetBool("Moving", true);
        anim.SetInteger("State", (int)state); //sets animation based on enuemrator state */
        if (Input.GetKey(KeyCode.Space)&&delay>10)
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
        if (health ==0)
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
        if(Blue_bullet.activeInHierarchy ) { 
        }
        bullet = Blue_bullet;   
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
    
         else if(Mathf.Abs(rb.velocity.x) > 2f)
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
