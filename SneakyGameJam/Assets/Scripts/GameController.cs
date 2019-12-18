using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool gameOver = false, winner = false;
    public string gameScene;

    public GameObject endScreen;
    public Text gameOverText;


    void Start()
    {
        Cursor.visible = false;

        endScreen.SetActive(false);

        //winner = true; // test condition
        //GameOver(); // test method
    }

    
    void Update()
    {
        if (gameOver && Input.GetKey("r"))
            SceneManager.LoadScene(gameScene);

        if (Input.GetKey("escape"))
            Application.Quit();

    }

    public void GameOver()
    {
        endScreen.SetActive(true);
        gameOver = true;

        if(winner)
        {
            gameOverText.text = "You Win";
        }
        else
        {
            gameOverText.text = "Game Over";
        }


    }

 

}
