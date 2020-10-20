using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    float hueValue;
    public TextMeshProUGUI bestScoreText;
    void Start()
    {
        SetBackgroundColor();
        bestScoreText.text = PlayerPrefs.GetInt("BestScore",0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetBackgroundColor()
    {
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.6f);

        hueValue += 0.1f;
        if (hueValue >= 1)
        {
            hueValue = 0;
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
}
