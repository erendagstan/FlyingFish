using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameover;
    public GameObject gameOverPanel;
    public GameObject getReady;
    public static int gameScore;
    public GameObject score;
 
    public static bool gameStarted;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        gameStarted = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameHasStarted()
    {
        gameStarted=true;
        getReady.SetActive(false);
    }

    public void GameOver()
    {
        gameover=true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore=score.GetComponent<Score>().GetScore();
    }
}
