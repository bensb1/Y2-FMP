using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum BulletType { Normal, Green, blue, purple };
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

    public BulletType bulletType = BulletType.Normal;
    Rigidbody2D rb;
    public float speed;
    int startHealth = 3;
    public int currentHealth;
    private float timer = 0f;
    private float waitTimer = 2f;
    private Fuel Fuel;
    public AudioSource shootSoundEffect;
    private Scene scene;
    private Boss boss;
    


    private void Awake()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boss = GetComponent<Boss>();
        a = transform.Find("a").gameObject;
        
        b = transform.Find("b").gameObject;
    }
    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        bulletType = (BulletType)PlayerPrefs.GetInt("playerWithBullet");
        Debug.Log(bulletType);

        Fuel = GameObject.Find("FuelBar").GetComponent<Fuel>();
        currentHealth = PlayerPrefs.GetInt("Health");
        if (currentHealth <= 0)
        {
            PlayerPrefs.SetInt("Health", startHealth);
            currentHealth = 3;
            


        }


    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));

        Boost();

        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
        Boost();
        // anim.SetBool("Moving", true);
        anim.SetInteger("State", (int)state); //sets animation based on enuemrator state */
        if (Input.GetKey(KeyCode.Space) && delay > 10)
        {
            Shoot();


        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }

        delay++;
        AnimationState();
        loadscene();
        


    }
    public void Damage()
    {
        StartCoroutine(Blink());
        currentHealth--;
        PlayerPrefs.SetInt("Health", currentHealth);
        if (currentHealth == 0)
        {
            Destroy(this);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.1f);
            currentHealth = PlayerPrefs.GetInt("Health", startHealth);
            PlayerPrefs.SetInt("isBossDead", 0);
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
        shootSoundEffect.Play();
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
                bullet = Purple_Bullet;
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
        currentHealth++;
        PlayerPrefs.SetInt("Health", currentHealth);
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
    public void Boost()
    {
        if (Input.GetKey(KeyCode.B))

        {
            if (timer > waitTimer)
            {

                Fuel.UseFuel(15);

                timer = 0;
            }
            speed = 4f;
        }
        if (!Input.GetKey(KeyCode.B))
        {
            speed = 2f;
        }
        else
        {
            Fuel.fuelEmpty();
        }


    }
    public void loadscene()
    {
        if(PlayerPrefs.GetInt("isBossDead") == 0)
        {
            if (SceneManager.GetActiveScene().name != "Boss")
            {
                if (PlayerPrefs.GetInt("Score") >= 5000)
                {
                    SceneManager.LoadScene("Boss");
                }
            }

        }

    }

}
