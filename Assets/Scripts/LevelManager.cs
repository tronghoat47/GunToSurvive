using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float Score;
    public float Highscore;

    public Text ScoreText;
    public Text HighScoreText;

    public void AddScore()
    {
        Score++;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = $"Score: {Score}";
        HighScoreText.text = $"High Score: {Highscore}";

    }
}
