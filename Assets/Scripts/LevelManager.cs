using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager manager;
    public float Score;
    public float Highscore;

    public Text ScoreText;
    public Text HighScoreText;


    private void Awake()
    {
        manager = this;
    }
    public void AddScore(float plusCore)
    {
        Score += plusCore;
    }


    // Start is called before the first frame update
    void Start()
    {
        Highscore = PlayerPrefs.GetFloat("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = $"Score: {Score}";
        HighScoreText.text = $"High Score: {Highscore}";
        if (Score > Highscore)
        {
            Highscore = Score;
            PlayerPrefs.SetFloat("HighScore", Score);
        }
    }
}
