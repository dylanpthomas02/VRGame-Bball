using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public TextMeshProUGUI timerText;
    [SerializeField]
    private float startTime = 60;
    public float currentTime = 0;
    public bool isPlaying = false;

    void Start()
    {
        currentTime = startTime;
        SetUI();
    }

    void Update()
    {
        if (currentTime > 0 && isPlaying)
        {
            currentTime -= Time.deltaTime;
            SetUI();
        }
        else
        {
            StopTimer();
        }
    }

    public void StartTimer()
    {
        isPlaying = true;
    }

    private void StopTimer()
    {
        isPlaying = false;
    }

    public void ResetTimer()
    {
        currentTime = startTime;
        SetUI();
    }

    public void SetUI()
    {
        timerText.text = currentTime.ToString("F0");
    }
}
