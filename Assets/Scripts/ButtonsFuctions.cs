using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsFuctions : MonoBehaviour
{
public void Quit()
    {
        Application.Quit();
    }
    public void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void BossBattleToContinue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
    }
    public void BossBattleToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
    }
    public void MainMenuToInstructions()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
    }
}
