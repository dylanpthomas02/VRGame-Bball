using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public static FinalScore finalScore;
    public TextMeshProUGUI finalScoreText;

    public void FinalScoreUI()
    {
        finalScoreText.text = ScoreManager.instance.playerScore.ToString();
    }
}