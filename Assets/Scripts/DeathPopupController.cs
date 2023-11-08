using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathPopupController : MonoBehaviour
{
    [SerializeField] public GameObject DeathManager;

    [SerializeField] public Text hScore;

    public string s;
    public Text ScoreText;
    public Text HighScoreText;
    float highScore;

    public void ShowDeathScreen()
    {
        ScoreText.text = $"Your score: {LevelManager.manager.Score}";
        
        DeathManager.SetActive(true);
        Time.timeScale = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        hScore.text = s;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
