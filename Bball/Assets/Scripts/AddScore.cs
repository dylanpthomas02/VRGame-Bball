using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    //TODO: setup particle system for successful shot
    public ParticleSystem ps;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Basketball"))
        {
            Ball ball = other.GetComponent<Ball>();
            int score = ball.scoreAmount;
            ScoreManager.instance.AddScore(score);

            ps.Play();
            FindObjectOfType<AudioManager1>().Play("ScoreSuccess");
            FindObjectOfType<AudioManager1>().Play("Net");
        }
    }
}
