using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    void Start()
    {
        scoreText.text = ScoreManager.instance.playerScore.ToString();
        timerText.text = Timer.instance.currentTime.ToString();
    }

    void Update()
    {
        scoreText.text = ScoreManager.instance.playerScore.ToString();
        timerText.text = Timer.instance.currentTime.ToString("F1");
    }
}
