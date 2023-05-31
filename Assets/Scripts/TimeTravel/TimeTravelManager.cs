using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum TravelTo
{
    PAST,
    FUTURE
}

public class TimeTravelManager : MonoBehaviour
{
    [SerializeField] private JournalSO journal;
    [SerializeField] private TimeTravelSO timeTravelManager;
    [SerializeField] private TravelTo travelTo;

    private void OnEnable()
    {
        timeTravelManager.TimeTravelEvent.AddListener(TimeTravel);
    }

    private void OnDisable()
    {
        timeTravelManager.TimeTravelEvent.RemoveListener(TimeTravel);
    }


    public void TimeTravel()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (travelTo == TravelTo.PAST)
        {
            journal.canUnlockLetter = true;
            sceneName = sceneName.Replace("Future", "Past");
        }
        else if (travelTo == TravelTo.FUTURE)
        {
            journal.canUnlockLetter = false;
            sceneName = sceneName.Replace("Past", "Future");
        }
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
