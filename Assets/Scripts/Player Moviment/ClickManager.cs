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

    public Vector3 initialPosition;
    public bool redirect = false;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
        initialPosition = Player.position;
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
        if (initialPosition != Player.position)
        {
            redirect = true;
        }

        initialPosition = Player.position;
        StartCoroutine(MoveToPoint(itemData.goToPoint.position));
    }

    public virtual IEnumerator MoveToPoint(Vector2 point)
    {
        Debug.Log(redirect);
        Vector2 positionDifference = point - (Vector2)Player.position;

        yield return new WaitUntil(() => redirect == false);

        while (positionDifference.magnitude > moveAccuracy && redirect == false)
        {
            Player.Translate(moveSpeed * positionDifference.normalized * Time.deltaTime);
            positionDifference = point - (Vector2)Player.position;
            yield return null;
        }

        if (!redirect)
        {
            Player.position = point;
            initialPosition = Player.position;
        }

        yield return null;

        redirect = false;
    }
}



