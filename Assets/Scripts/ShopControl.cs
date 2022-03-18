using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{
    int Coins;
    int isBluebulletSold;

    public Text moneyAmountText;
    public Text BluebulletPrice;
    public Button buyButton;
    private void Start()
    {
        Coins = PlayerPrefs.GetInt("Coins");
    }
    private void Update()
    {
        moneyAmountText.text = "Money:" + Coins.ToString() + "$";
        isBluebulletSold = PlayerPrefs.GetInt("isBluebulletSold");
        if (Coins >= 8 && isBluebulletSold == 0)
        {
            buyButton.interactable = true;

        }
        else
        {
            buyButton.interactable = false;
        }
    }
    public void buyBluebullet()
    {

        Coins -= 8;
        PlayerPrefs.SetInt("Coins", Coins);

        PlayerPrefs.SetInt("isBluebulletSold", 1);
        BluebulletPrice.text = "Sold!";
        buyButton.gameObject.SetActive(false);
        
        
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
}
