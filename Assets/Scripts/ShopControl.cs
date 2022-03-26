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
    int isPurplebulletSold;

    public Text moneyAmountText;
    public Text BluebulletPrice,GreenbulletPrice;
    public Button buyButton;
    public Button buyButtonGreen;
        public Button buyButtonPurple;
    public GameObject Bluebullet;
    
    

    private void Start()
    {

        Coins = PlayerPrefs.GetInt("Coins");
    }
    private void Update()
    {
        moneyAmountText.text = "Money:" + Coins.ToString() + "$";
        isBluebulletSold = PlayerPrefs.GetInt("isBluebulletSold");
        isGreenbulletSold = PlayerPrefs.GetInt("isGreenbulletSold");
        isPurplebulletSold = PlayerPrefs.GetInt("isPurplebulletSold");
        if (Coins >= 50 && isBluebulletSold == 0)
        {
            buyButton.interactable = true;

        }
        else
        {
            buyButton.interactable = false;
        }
        if (Coins >= 250 && isGreenbulletSold ==0)
        {
            buyButtonGreen.interactable = true;
              
        }
        else
        {
            buyButtonGreen.interactable = false;
        }
        if (Coins >= 350 && isPurplebulletSold == 0)
        {
            buyButtonPurple.interactable = true;

        }
        else
        {
            buyButtonPurple.interactable = false;
        }
    }
    public void buyBluebullet()
    {

        Coins -= 50;
        PlayerPrefs.SetInt("Coins", Coins);

        PlayerPrefs.SetInt("isBluebulletSold", 1);
        BluebulletPrice.text = "Sold!";
        buyButton.gameObject.SetActive(false);
      
        
        
         PlayerPrefs.SetInt("playerWithBullet",( int) BulletType.blue );
        
        



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

        Coins -=250;
        PlayerPrefs.SetInt("Coins", Coins);

        PlayerPrefs.SetInt("isGreenbulletSold", 1);
        GreenbulletPrice.text = "Sold!";
        buyButtonGreen.gameObject.SetActive(false);
        PlayerPrefs.SetInt("playerWithBullet", (int)BulletType.Green);







    }
    public void buyPurpleBullet()
    {

        Coins -= 1;
        PlayerPrefs.SetInt("Coins", Coins);

        PlayerPrefs.SetInt("isPurplebulletSold", 1);
        GreenbulletPrice.text = "Sold!";
        buyButtonPurple.gameObject.SetActive(false);
        PlayerPrefs.SetInt("playerWithBullet", (int)BulletType.purple);





    }

}
