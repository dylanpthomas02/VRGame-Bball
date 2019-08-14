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
    // TODO: Reset level setup without reloading the level. 
    // Spawn racks, reset score and timer, etc.
    public static GameManager instance = null;

    public TextMeshProUGUI messageText;
    public GameObject cameraRig;
    public GameObject StartMenu;
    public GameObject GameCompleteMenu;
    public GameObject PauseMenu;
    public Vector3 menuOffset;

    public int balls = 0;

    List<Ball> ballList = new List<Ball>();

    private float m_StartDelay = 3f;
    private WaitForSeconds m_StartWait;

    public GameObject lController;
    public GameObject rController;
    bool isPaused = false;

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
            return;
        }

        GameCompleteMenu.SetActive(false);
        PauseMenu.SetActive(false);
    }

    private void Start()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        DisableHandControl();
    }

    private void Update()
    {
        CheckForPause();
    }

    void CheckForPause()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            isPaused = !isPaused;
            PauseMenu.SetActive(isPaused);
            PauseMenu.transform.position = cameraRig.transform.TransformPoint(menuOffset);
            Vector3 newEulerRot = cameraRig.transform.rotation.eulerAngles;
            newEulerRot.x = 0.0f;
            newEulerRot.z = 0.0f;
            PauseMenu.transform.eulerAngles = newEulerRot;
            Pause(isPaused);
        }
    }

    public void StartGameButton()
    {
        StartCoroutine(GameLoop());
    }

    void DisableHandControl()
    {
        // Disable grab functionality before game start by making grabBegin higher than is possible.
        lController.GetComponent<DistanceGrabber>().grabBegin = 1.1f;
        rController.GetComponent<DistanceGrabber>().grabBegin = 1.1f;
    }

    void EnableHandControl()
    {
        lController.GetComponent<DistanceGrabber>().grabBegin = 0.3f;
        rController.GetComponent<DistanceGrabber>().grabBegin = 0.8f;
    }


    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());
    }

    private IEnumerator RoundStarting()
    {
        StartMenu.SetActive(false);
        messageText.text = "Get Ready!";

        yield return m_StartWait;
        PlayerScript.instance.gameStarted = true;
        messageText.text = "GO!!";
        EnableHandControl();
        FindObjectOfType<AudioManager1>().Play("GameStart");

        yield return new WaitForSeconds(1f);
    }

    private IEnumerator RoundPlaying()
    {
        Timer.instance.isPlaying = true;
        messageText.text = string.Empty;

        while (balls > 0 && Timer.instance.currentTime > 0)
        {
            yield return null;
        }
    }

    private IEnumerator RoundEnding()
    {
        DisableHandControl();
        Timer.instance.isPlaying = false;

        ScoreManager.instance.FinalScore();

        GameCompleteMenu.transform.position = cameraRig.transform.TransformPoint(menuOffset);
        Vector3 newEulerRot = cameraRig.transform.rotation.eulerAngles;
        newEulerRot.x = 0.0f;
        newEulerRot.z = 0.0f;
        GameCompleteMenu.transform.eulerAngles = newEulerRot;
        GameCompleteMenu.SetActive(true);
        FindObjectOfType<AudioManager1>().Play("GameEnd");

        yield return null;
    }

    public void Pause(bool isPaused)
    {
        int result = isPaused ? 0 : 1;
        Time.timeScale = result;
    }

    public void ResetLevel()
    {
        //TODO: Don't reload scene, reset it.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //Timer.instance.ResetTimer();
        //ScoreManager.instance.ResetScore();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
