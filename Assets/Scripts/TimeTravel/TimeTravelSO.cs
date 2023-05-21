using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TimeTravelSO", menuName = "ScriptableObjects/TimeTravel")]
public class TimeTravelSO : ScriptableObject
{
    public int currentActions;
    public float currentTime;
    [System.NonSerialized] public UnityEvent ExecuteActionEvent;

    private void OnEnable()
    {
        currentActions = 0;
        currentTime = 0;
        if (ExecuteActionEvent == null)
        {
            ExecuteActionEvent = new UnityEvent();
        }
    }

    public void ExecuteAction()
    {
        currentActions++;
        ExecuteActionEvent?.Invoke();
    }
}
