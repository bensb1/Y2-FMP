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
    // Start is called before the first frame update
    void Start()
    {


        currentFuel = maxFuel;
        slider.maxValue = maxFuel;
        slider.value = maxFuel;
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
        if (currentFuel - amount >= 0)
        {
            currentFuel -= amount;
            slider.value = currentFuel;
        }
    }

}

