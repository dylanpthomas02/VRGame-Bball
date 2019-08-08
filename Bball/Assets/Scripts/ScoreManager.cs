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
    public Animator anim;

    private static int playerScore;
    private int popupScore;

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
        popupScore = 0;
        UpdateScoreUI();
    }

    public void AddScore(int ballScore)
    {
        playerScore += ballScore;
        popupScore = ballScore;
        if (popupScore > 0)
        {
            UpdateScoreUI();
        }
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

        // TODO: create popup score animation
        anim.SetTrigger("popup");
        //new WaitForSeconds(1f);
        //anim.SetBool("popup", false);

    }
}
