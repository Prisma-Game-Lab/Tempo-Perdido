using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public enum TriggerMode
{
    TIMER,
    ACTIONS
}

public class TimeTravelManager : MonoBehaviour
{
    [SerializeField] private TimeTravelSO timeTravelManager;
    [SerializeField] private TriggerMode triggerMode;

    [HideIfEnumValue("triggerMode", HideIf.NotEqual, (int)TriggerMode.TIMER)][SerializeField] private float totalTime = 0;
    [HideIfEnumValue("triggerMode", HideIf.NotEqual, (int)TriggerMode.TIMER)][SerializeField] private GameObject timerDisplay;
    [HideIfEnumValue("triggerMode", HideIf.NotEqual, (int)TriggerMode.ACTIONS)][SerializeField] private int totalActions = 0;

    private void OnEnable()
    {
        timeTravelManager.ExecuteActionEvent.AddListener(ExecutedAction);
    }

    private void OnDisable()
    {
        timeTravelManager.ExecuteActionEvent.RemoveListener(ExecutedAction);
    }

    void Start()
    {
        if (triggerMode == TriggerMode.ACTIONS)
        {
            timerDisplay.gameObject.SetActive(false);
        }
        else if (triggerMode == TriggerMode.TIMER)
        {
            if (timeTravelManager.currentTime == 0)
            {
                timeTravelManager.currentTime = totalTime;
            }
            timerDisplay.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        if (triggerMode == TriggerMode.TIMER)
        {
            timeTravelManager.currentTime -= Time.deltaTime;
            UpdateTimer(timeTravelManager.currentTime);

            if (timeTravelManager.currentTime <= 0.0f)
            {
                RewindTime();
            }
        }
    }

    public void ExecutedAction()
    {
        if (timeTravelManager.currentActions == totalActions)
        {
            RewindTime();
        }
    }

    private void UpdateTimer(float time)
    {
        time += 1;

        float hours = Mathf.FloorToInt(time / 60);
        float minutes = Mathf.FloorToInt(time % 60);

        string minutesText;

        if (minutes < 10)
        {
            minutesText = "0" + minutes.ToString();
        }
        else
        {
            minutesText = minutes.ToString();
        }

        timerDisplay.GetComponent<TMP_Text>().text = hours.ToString() + ":" + minutesText;
    }

    public void RewindTime()
    {
        timeTravelManager.currentActions = 0;
        timeTravelManager.currentTime = totalTime;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        Debug.Log("Rewinded");
    }
}
