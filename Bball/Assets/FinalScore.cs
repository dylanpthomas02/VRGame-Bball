using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Update()
    {
        if (finalScoreText.gameObject.activeSelf)
        {
            finalScoreText.text = ScoreManager.instance.scoreText.text;
        }
    }
}
