using OculusSampleFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject player;
    public GameObject StartMenu;
    public GameObject PauseMenu;
    public GameObject GameCompleteMenu;

    public int balls = 0;

    public Animator countdownAnim;

    private float m_StartDelay;
    private WaitForSeconds m_StartWait;
    List<Ball> ballList;
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

    private void Start()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);

        ballList = new List<Ball>();
        ballList = GetAllBasketballsInScene();
        balls = ballList.Count;
        TurnOffBasketballControl();

        StartCoroutine(GameLoop());
    }

    void TurnOffBasketballControl()
    {
        foreach (Ball ball in ballList)
        {
            GetComponentInChildren<DistanceGrabber>().enabled = false;
        }
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            PauseMenu.transform.position = player.transform.position + new Vector3(0, 0, 5);
            PauseMenu.transform.rotation = player.transform.rotation * Quaternion.Euler(0, 180, 0);
            PauseMenu.SetActive(true);
            gamePaused = !gamePaused;
            Pause(gamePaused);
        }
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

        //if (Timer.currentTime <= 0)
        //{
        //    GameCompleteMenu.SetActive(true);
        //}
        //else
        //{
        //    StartCoroutine(GameLoop());
        //}
    }

    private IEnumerator RoundStarting()
    {
        StartMenu.SetActive(false);

        yield return m_StartWait;

        foreach (Ball ball in ballList)
        {
            GetComponentInChildren<DistanceGrabber>().enabled = true;
        }
    }

    private IEnumerator RoundPlaying()
    {
        Timer.instance.isPlaying = true;

        while (balls > 0 && Timer.instance.currentTime > 0)
        {
            yield return null;
        }
    }

    private IEnumerator RoundEnding()
    {
        foreach (Ball ball in ballList)
        {
            GetComponentInChildren<DistanceGrabber>().enabled = false;
        }

        yield return null;
    }

    public List<Ball> GetAllBasketballsInScene()
    {
        List<Ball> ballsInScene = new List<Ball>();

        foreach (Ball ball in Resources.FindObjectsOfTypeAll(typeof(Ball)) as Ball[])
        {
            ballsInScene.Add(ball);
        }

        return ballsInScene;
    }

    public void Pause(bool isPaused)
    {
        int result = isPaused ? 0 : 1;
        Time.timeScale = result;
    }

    public void ResetGame()
    {
        Timer.instance.ResetTimer();
        ScoreManager.instance.ResetScore();
    }
}
