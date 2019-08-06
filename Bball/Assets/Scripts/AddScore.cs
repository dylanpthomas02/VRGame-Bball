using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Basketball"))
        {
            Ball ball = other.GetComponent<Ball>();
            int score = ball.scoreAmount;
            ScoreManager.instance.AddScore(score);

            FindObjectOfType<AudioManager1>().Play("ScoreSuccess");
        }
    }
}
