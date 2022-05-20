using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fuel : MonoBehaviour
{
    public Slider slider;
    public int maxFuel = 100;
    public int currentFuel;
    private Enemy enemy;
    private Spaceship spaceship;
    // Start is called before the first frame update
    void Start()
    { 
        
            spaceship = GameObject.Find("Player").GetComponent<Spaceship>();
        
        currentFuel = maxFuel;
        slider.maxValue = maxFuel;
        slider.value = maxFuel;
    }
    public void Update()
    {
        //Debug.Log("CF "+currentFuel);
    }

    // Update is called once per frame

    public void fuelReset()
    {

        currentFuel = maxFuel;
        slider.maxValue = maxFuel;
        slider.value = maxFuel;



    }


    public void UseFuel(int amount)
    {
      //  Debug.Log("CF TOTAL " + (currentFuel - amount));
      //  Debug.Log("CF " + (currentFuel ));
      //  Debug.Log("AMOUNT " + (amount));

        if (currentFuel  >= 0)
        {
            currentFuel -= amount;
            slider.value = currentFuel;
        }
     else
        {
            fuelEmpty();
        }
    }
    public void fuelEmpty()
    {
        if (currentFuel  <= 0)
        {
            spaceship.speed = 2f;
        }
    }

}

