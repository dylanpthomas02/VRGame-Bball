using OculusSampleFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //TODO: Method to instantiate basketball racks. And reset them.

    public static GameManager instance = null;

    public TextMeshProUGUI messageText;

    public GameObject player;
    public GameObject StartMenu;
    public GameObject PauseMenu;
    public GameObject GameCompleteMenu;

    public int balls = 0;
    public Animator countdownAnim;

    List<Ball> ballList = new List<Ball>();

    private float m_StartDelay = 3f;
    private WaitForSeconds m_StartWait;
    bool gamePaused = false;

    public GameObject lController;
    public GameObject rController;

    void Awake()
    {
        Ball[] ballArray = (Ball[]) Resources.FindObjectsOfTypeAll(typeof(Ball));

        foreach (Ball ball in ballArray)
        {
            ballList.Add(ball);
        }
        balls = ballList.Count;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        GameCompleteMenu.SetActive(false);
        PauseMenu.SetActive(false);
    }

    private void Start()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        DisableHandControl();
    }

    void Update()
    {
        CheckForPause();
    }

    public void StartGameButton()
    {
        StartCoroutine(GameLoop());
    }

    void DisableHandControl()
    {
        lController.GetComponent<DistanceGrabber>().grabBegin = 1.1f;
        rController.GetComponent<DistanceGrabber>().grabBegin = 1.1f;
    }

    void EnableHandControl()
    {
        lController.GetComponent<DistanceGrabber>().grabBegin = 0.3f;
        rController.GetComponent<DistanceGrabber>().grabBegin = 0.3f;
    }

    void CheckForPause()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            PauseMenu.transform.position = player.transform.position + new Vector3(0, 0, 10);
            PauseMenu.transform.rotation = player.transform.rotation;
            gamePaused = !gamePaused;
            PauseMenu.SetActive(gamePaused);
            Pause(gamePaused);
        }
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

        //if (Timer.instance.currentTime <= 0 || balls <= 6)
        //{
        //    Debug.Log("GameLoop finished");
        //}
        //else
        //{
        //    StartCoroutine(GameLoop());
        //}
    }

    private IEnumerator RoundStarting()
    {
        StartMenu.SetActive(false);
        messageText.text = "Get Ready!";

        yield return m_StartWait;

        messageText.text = "GO!!";
        EnableHandControl();
        //FindObjectOfType<AudioManager1>().Play("GameStart");

        yield return new WaitForSeconds(1f);
    }

    private IEnumerator RoundPlaying()
    {
        Timer.instance.isPlaying = true;
        messageText.text = string.Empty;

        while (balls > 6 && Timer.instance.currentTime > 0)
        {
            yield return null;
        }
    }

    private IEnumerator RoundEnding()
    {
        DisableHandControl();
        Timer.instance.isPlaying = false;

        messageText.text = "Game Over!";
        GameCompleteMenu.SetActive(true);

        yield return null;
    }

    public void Pause(bool isPaused)
    {
        int result = isPaused ? 0 : 1;
        Time.timeScale = result;
    }

    public void ResetLevel()
    {
        //TODO: Don't reload scene, just reset everything.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        // TODO: Need a method to reset basketball racks
        //Timer.instance.ResetTimer();
        //ScoreManager.instance.ResetScore();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
