using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClickManager : MonoBehaviour, IPointerClickHandler
{
    float moveAccuracy = 0.15f;
    public Transform Player;
    [SerializeField] public ItemData itemData;
    public MovementSO movementSO;
    public bool interrupted;
    public GameObject popUp;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
        movementSO.initialPosition = Player.position;

        if (popUp != null)
        {
            popUp.SetActive(false);
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (itemData.goToPoint.position.x < Player.position.x)
        {
            Player.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }

        else
        {
            Player.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
        }

        Interact();
    }

    public void Interact()
    {
        GoToItem();
    }

    public void GoToItem()
    {
        if (movementSO.canMove)
        {
            if (movementSO.initialPosition != Player.position)
            {
                movementSO.redirect = true;
            }

            movementSO.initialPosition = Player.position;
            StartCoroutine(MoveToPoint(itemData.goToPoint.position));
        }
    }

    public virtual IEnumerator MoveToPoint(Vector2 point)
    {
        Player.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("walking", true);
        Vector2 positionDifference = point - (Vector2)Player.position;

        yield return new WaitUntil(() => movementSO.redirect == false);

        while (positionDifference.magnitude > moveAccuracy && movementSO.redirect == false)
        {
            Player.Translate(movementSO.moveSpeed * positionDifference.normalized * Time.deltaTime);
            positionDifference = point - (Vector2)Player.position;
            yield return null;
        }

        if (!movementSO.redirect)
        {
            Player.position = point;
            movementSO.initialPosition = Player.position;
        }

        yield return null;

        if (movementSO.redirect)
        {
            interrupted = true;
        }

        movementSO.redirect = false;
        Player.gameObject.transform.GetChild(0).GetComponent<Animator>().SetBool("walking", false);
    }

    public void OnHoverEnter()
    {
        if (popUp != null)
        {
            popUp.SetActive(true);
        }
    }

    public void OnHoverExit()
    {
        if (popUp != null)
        {
            popUp.SetActive(false);
        }
    }
}



