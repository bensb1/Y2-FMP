using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject player;
    bool gameOver = false;
    private Spaceship spaceship;

    // Start is called before the first frame update
    void Start()
    {
        spaceship = GameObject.Find("Player").GetComponent<Spaceship>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player==null&&!gameOver)
        {
            Debug.Log("gameover:" + gameOver);
            Debug.Log("player:" + player);
 
            GameOver();
            StartCoroutine(LoadGameOver());
        }
    }
    void GameOver()
    {
        gameOver = true;
        if(PlayerPrefs.GetInt("Score")>PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
        }
    }
    IEnumerator LoadGameOver()
    {
         yield return new WaitForSeconds(2f);
        
        
        if(SceneManager.GetActiveScene().name == "Boss" )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2 );
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
