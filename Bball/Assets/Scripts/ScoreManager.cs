using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Transform player;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI popupText;
    public TextMeshProUGUI finalScoreText;
    public Animator popupAnim;

    public int playerScore { get; set; }

    private int popupScore = 0;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
            return;
    }

    void Start()
    {
        playerScore = 0;
        scoreText.text = playerScore.ToString();
    }

    public void AddScore(int ballScore)
    {
        if (ballScore > 0)
        {
            playerScore += ballScore;
            popupScore = ballScore;
            UpdateScoreUI();
        }
    }

    public void FinalScore()
    {
        finalScoreText.text = playerScore.ToString();
    }

    public void ResetScore()
    {
        playerScore = 0;
        popupScore = 0;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        popupText.text = "+" + popupScore.ToString();
        scoreText.text = playerScore.ToString();
        popupAnim.SetTrigger("popup");
    }
}
