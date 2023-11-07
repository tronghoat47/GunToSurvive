using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathPopupController : MonoBehaviour
{
    [SerializeField] public GameObject DeathManager;

    public Text ScoreText;
    public Text HighScoreText;
    float highScore;

    public void ShowDeathScreen()
    {
        ScoreText.text = $"Your score: {LevelManager.manager.Score}";
        
        HighScoreText.text = $"High score: {highScore}";
        DeathManager.SetActive(true);
        Time.timeScale = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetFloat("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
