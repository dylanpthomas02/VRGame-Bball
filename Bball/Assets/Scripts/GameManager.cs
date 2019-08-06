using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject StartMenu;
    public GameObject PauseMenu;
    public GameObject CountdownTimer;

    public Animator countdownAnim;

    bool gamePaused = false;

    void Awake()
    {
        if (instance == null)
        {
            Debug.Log("creating GameManager");
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        CountdownTimer.SetActive(false);
    }

    public void StartGame()
    {
        StartMenu.SetActive(false);
        StartCoroutine( StartCountdownTimer() );
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            Debug.Log("Pause");
            PauseMenu.transform.position = transform.position + new Vector3(0, 0, 5);
            PauseMenu.transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
            PauseMenu.SetActive(true);
            gamePaused = !gamePaused;
            //Pause(gamePaused);
        }
    }

    public void EndGame()
    {

    }

    public void Pause(bool isPaused)
    {
        int result = isPaused ? 0 : 1;
        Time.timeScale = result;
    }

    IEnumerator StartCountdownTimer()
    {
        CountdownTimer.SetActive(true);
        countdownAnim.Play("Countdown");

        yield return new WaitForSeconds(3);
    }

    public void ResetGame()
    {
        StartMenu.SetActive(true);
    }
}
