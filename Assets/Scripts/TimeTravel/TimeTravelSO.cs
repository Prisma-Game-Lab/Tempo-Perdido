using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TimeTravelSO", menuName = "ScriptableObjects/TimeTravel")]
public class TimeTravelSO : ScriptableObject
{
    [System.NonSerialized] public UnityEvent TimeTravelEvent;


    private void OnEnable()
    {
        if (TimeTravelEvent == null)
        {
            TimeTravelEvent = new UnityEvent();
        }
    }

    public void TimeTravel()
    {
        TimeTravelEvent?.Invoke();
    }
}
