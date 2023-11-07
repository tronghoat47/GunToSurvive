using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControlller : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    Text txtScore;

    void Start()
    {
        txtScore = canvas.transform.Find("TextMyScore").GetComponent<Text>();
    }

    void Update()
    {
        
    }
}
