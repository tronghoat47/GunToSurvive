using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerCs : MonoBehaviour
{
    public string sceneName;

    [SerializeField]
    Text hhowToPlay;

    private bool isSHow = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSHow) {
            hhowToPlay.text = "A - left, W - Up, S - Down, D - right" + "\n" + "C for scrolling" + "\n" + "Space to use sweeping skills"
                + "Left mouse to shot" + "\n"
                + "Items will be auto created in runtime"
                + "Enemies will increase their health after an amount of time";
        }
    }

    public void HowToPlay() {
        isSHow = !isSHow;
    }

    public void UpdateScene() {
        SceneManager.LoadScene(sceneName);
    }
}
