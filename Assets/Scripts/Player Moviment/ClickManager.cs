using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    float moveSpeed = 3.5f, moveAccuracy = 0.15f;
    public Transform Player;

    // PARTE NOVA {
    /*private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        myCamera = GetComponent<Camera>();
    }

    public void Update()
    {
        if (Input.GetMouseButtonUp(0))
            goToClickCoroutine = StartCoroutine(GoToClick(Input.mousePosition));
    }

    public IEnumerator GoToClick(Vector2 mousePos)
    {
        Vector2 targetPos = myCamera.ScreenToWorldPoint(mousePos);
        StartCoroutine(gameManager.MoveToPoint(Player, targetPos));
    }*/
    // PARTE NOVA }

    public void GoToItem(ItemData item)
    {
        StartCoroutine(MoveToPoint(item.goToPoint.position));
    }

    public void GoToItem(ItemDataFloor item)
    {
        StartCoroutine(MoveToPoint(item.goToPoint.position));
    }

    public IEnumerator MoveToPoint(Vector2 point)
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



