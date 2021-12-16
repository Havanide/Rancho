using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetersIncrease : MonoBehaviour
{

    [SerializeField] public Text scoreText;
    private int score = 0;

    void Start()
    {
        InvokeRepeating("AddScore", 2f, 10f);
    }

    public void AddScore()
    {
        scoreText.text = score++.ToString();
    }
}
