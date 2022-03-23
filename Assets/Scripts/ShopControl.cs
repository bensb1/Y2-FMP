using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{
    int Coins;
    int isBluebulletSold;
    int isGreenbulletSold;

    public Text moneyAmountText;
    public Text BluebulletPrice,GreenbulletPrice;
    public Button buyButton;
    public Button buyButtonGreen;
        public Button buyButtonPurple;
    public GameObject Bluebullet;
    private GameObject Player;

    private void Start()
    {

        Coins = PlayerPrefs.GetInt("Coins");
    }
    private void Update()
    {
        moneyAmountText.text = "Money:" + Coins.ToString() + "$";
        isBluebulletSold = PlayerPrefs.GetInt("isBluebulletSold");
        isBluebulletSold = PlayerPrefs.GetInt("isGreenbulletSold");
        if (Coins >= 8 && isBluebulletSold == 0)
        {
            buyButton.interactable = true;

        }
        else
        {
            buyButton.interactable = false;
        }
        if (Coins >= 1 && isGreenbulletSold ==0)
        {
            buyButtonGreen.interactable = true;
              
        }
        else
        {
            buyButtonGreen.interactable = false;
        }
    }
    public void buyBluebullet()
    {

        Coins -= 8;
        PlayerPrefs.SetInt("Coins", Coins);

        PlayerPrefs.SetInt("isBluebulletSold", 1);
        BluebulletPrice.text = "Sold!";
        buyButton.gameObject.SetActive(false);
        
        Spaceship ship = GameObject.Find("Player").GetComponent<Spaceship>();
        ship.Blue_bullet.SetActive(true);
        ship.bulletType = Spaceship.BulletType.blue;
        



    }
    public void resetPlayerPrefs()
    {
        Coins = 0;
        buyButton.gameObject.SetActive(true);
        BluebulletPrice.text = "Price: 100$";
        PlayerPrefs.DeleteAll();
    }
    public void exitButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void buyGreenBullet()
    {

        Coins -=1;
        PlayerPrefs.SetInt("Coins", Coins);

        PlayerPrefs.SetInt("isGreenbulletSold", 1);
        GreenbulletPrice.text = "Sold!";
        buyButtonGreen.gameObject.SetActive(false);
        Spaceship ship = GameObject.Find("Player").GetComponent<Spaceship>();
        ship.bulletType = Spaceship.BulletType.Green;




    }
    public void buyPurpleBullet()
    {

        Coins -= 1;
        PlayerPrefs.SetInt("Coins", Coins);

        PlayerPrefs.SetInt("isGreenbulletSold", 1);
        GreenbulletPrice.text = "Sold!";
        buyButtonGreen.gameObject.SetActive(false);
        Spaceship ship = GameObject.Find("Player").GetComponent<Spaceship>();
        ship.bulletType = Spaceship.BulletType.Green;




    }

}
