using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI bestScoreText,bestText;
    public TextMeshProUGUI currentScoreText,currentText;

    int currentScore;
    void Start()
    {
        currentScore = 0;
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        SetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CallGameOver()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        currentScoreText.color = Color.white;
        currentText.color = Color.white;
        bestText.color = Color.white;
        bestScoreText.color = Color.white;
        gameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void AddScore()
    {
        currentScore++;
        if(currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            bestScoreText.text = currentScore.ToString();
        }
        SetScore();
    }

    public void SetScore()
    {
        currentScoreText.text = currentScore.ToString();
    }
}
