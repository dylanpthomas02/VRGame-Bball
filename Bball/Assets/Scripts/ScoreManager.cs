using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI popupText;
    Animator anim;

    private static int playerScore;
    private int popupScore;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
            return;
    }

    void Start()
    {
        playerScore = 0;
        popupScore = 0;
        SetUI();
    }

    public void AddScore(int ballScore)
    {
        playerScore += ballScore;
        popupScore = ballScore;
        if (popupScore > 0)
        {
            SetUI();
        }
    }

    public void ResetScore()
    {
        playerScore = 0;
        popupScore = 0;
        SetUI();
    }

    void SetUI()
    {
        popupText.text = "+" + popupScore.ToString();
        scoreText.text = playerScore.ToString();

        // TODO: create popup score animation
        //anim.Play("popup");
    }
}
