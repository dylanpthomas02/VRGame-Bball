using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject StartMenu;
    public GameObject PauseMenu;

    public Animator countdownAnim;

    private float m_StartDelay;
    private WaitForSeconds m_StartWait;

    bool gamePaused = false;

    private void Start()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);

        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());
    }

    private IEnumerator RoundStarting()
    {
        yield return m_StartWait;
    }

    private IEnumerator RoundPlaying()
    {
        yield return null;
    }

    private IEnumerator RoundEnding()
    {
        yield return null;
    }

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
        StartCoroutine( StartCountdownTimer() );
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            Debug.Log("Pause");
            PauseMenu.transform.position = transform.position + new Vector3(0, 0, 5);
            PauseMenu.transform.rotation = transform.rotation * Quaternion.Euler(0, 180, 0);
            PauseMenu.SetActive(true);
            gamePaused = !gamePaused;
            Pause(gamePaused);
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
        countdownAnim.Play("Countdown");

        yield return new WaitForSeconds(3);
    }

    public void ResetGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
