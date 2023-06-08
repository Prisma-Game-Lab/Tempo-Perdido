using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClickManager : MonoBehaviour, IPointerClickHandler
{
    float moveSpeed = 3.5f, moveAccuracy = 0.15f;
    public Transform Player;
    [SerializeField] public ItemData itemData;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Interact();
    }

    public void Interact()
    {
        GoToItem();
    }

    public void GoToItem()
    {
        StartCoroutine(MoveToPoint(itemData.goToPoint.position));
    }

    public virtual IEnumerator MoveToPoint(Vector2 point)
    {
        Vector2 positionDifference = point - (Vector2)Player.position;
        while (positionDifference.magnitude > moveAccuracy)
        {
            Player.Translate(moveSpeed * positionDifference.normalized * Time.deltaTime);
            positionDifference = point - (Vector2)Player.position;
            yield return null;
        }
        Player.position = point;

        yield return null;
    }
}



