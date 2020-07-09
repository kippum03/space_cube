using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private bool isGameActive;

    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnSphere());
        score = 0;
        InvokeRepeating("UpdateScore", 2, 1);
    
    }
   
    void UpdateScore()
    {
       if (isGameActive)
        {
            score += 1;
            scoreText.text = "Score: " + score;
        }
        
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over You survived for " + score + " seconds";
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    IEnumerator SpawnSphere()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(2);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    
    }
}
