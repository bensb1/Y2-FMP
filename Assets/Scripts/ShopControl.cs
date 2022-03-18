using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopControl : MonoBehaviour
{
    int moneyAmount;
    int isBluebulletSold;

    public Text moneyAmountText;
    public Text BluebulletPrice;
    public Button buyButton;
    private void Start()
    {
        moneyAmount = PlayerPrefs.GetInt("MoneyAmount");
    }
    private void Update()
    {
        moneyAmountText.text = "Money:" + moneyAmount.ToString() + "$";
        isBluebulletSold = PlayerPrefs.GetInt("isBluebulletSold");
        if (moneyAmount >= 100 && isBluebulletSold == 0)
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
        moneyAmount -= 100;
        PlayerPrefs.SetInt("isBluebulletSold", 1);
        BluebulletPrice.text = "Sold!";
        buyButton.gameObject.SetActive(false);
    }
    public void resetPlayerPrefs()
    {
        moneyAmount = 0;
        buyButton.gameObject.SetActive(true);
        BluebulletPrice.text = "Price: 100$";
        PlayerPrefs.DeleteAll();
    }
}
