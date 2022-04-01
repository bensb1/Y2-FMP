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
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
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
            
            bossChild.Length.GetType(gameObject.SetActive(true));
          //  Instantiate(bossChild, bossChild.transform.position, Quaternion.identity);
        }
    }
}
