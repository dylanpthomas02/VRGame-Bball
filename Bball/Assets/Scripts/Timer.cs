using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public TextMeshProUGUI timerText;
    [SerializeField]
    private float startTime = 60;
    public float currentTime = 0;
    public bool isPlaying = false;

    private void Awake()
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

    void Start()
    {
        currentTime = startTime;
        SetUI();
    }

    void Update()
    {
        TimerCountdown();
    }

    private void TimerCountdown()
    {
        if (currentTime > 0 && isPlaying)
        {
            currentTime -= Time.deltaTime;
            SetUI();
        }
        else
        {
            isPlaying = false;
        }
    }

    public void ResetTimer()
    {
        currentTime = startTime;
        SetUI();
    }

    public void SetUI()
    {
        timerText.text = currentTime.ToString("F1");
    }
}
