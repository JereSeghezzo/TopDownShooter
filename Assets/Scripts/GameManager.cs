using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text EnemyCounter;
    public int enemyCount;

    public GameObject HUD;
    public GameObject WinScreen;
    public GameObject LoseScreen;

    void Awake()
    {
      WinScreen.SetActive(false);   
      LoseScreen.SetActive(false);
      enemyCount = 10;
    }

    void Update()
    {

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
      EnemyCounter.text = enemyCount.ToString();   

      if(enemyCount == 0)
     {
       Win();  
     }
    }

    public void Kill()
    {
      enemyCount -= 1;   
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Win()
    {
     HUD.SetActive(false); 
     WinScreen.SetActive(true); 
     Time.timeScale = 0f;
    }

    public void Lose()
    {
     HUD.SetActive(false); 
     LoseScreen.SetActive(true); 
     Time.timeScale = 0f;
    }
}
