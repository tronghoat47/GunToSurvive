using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] public GameObject PauseMenuPanel;
    public Text currentHPText;
    public Text currentManaText;
    public Text currentSheildText;
    public Text currentLevelText;


    public void Pause()
    {
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;

    }

    public void ShowInforPlayer(float currentHP, float currentHPMax,
                    float currentMana, float currentManaMax,
                    float currentSheild, float currentSheildMax)
    {
        currentHPText.text = $"HP: {currentHP}/{currentHPMax}";
        currentManaText.text = $"Mana: {currentMana}/{currentManaMax}";
        currentSheildText.text = $"Sheild: {currentSheild}/{currentSheildMax}";
        currentLevelText.text = "";
    }

    public void Resume()
    {
        PauseMenuPanel.SetActive(false);
        Time.timeScale= 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }


}
