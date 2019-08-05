using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject StartMenu;

    public GameObject PauseMenu;

    bool gamePaused = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void StartGame()
    {
        StartMenu.SetActive(false);
        StartCountdownTimer();
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            PauseMenu.SetActive(true);
            gamePaused = !gamePaused;
            Pause(gamePaused);
        }
    }

    public void Pause(bool isPaused)
    {
        int result = isPaused ? 0 : 1;
        Time.timeScale = result;
    }

    private void StartCountdownTimer()
    {

    }

    void ResetGame()
    {
        StartMenu.SetActive(true);
    }
}
