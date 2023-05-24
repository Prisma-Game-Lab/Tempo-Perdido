using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class GameManager : MonoBehaviour
{
    static float moveSpeed = 3.5f, moveAccuracy = 0.15f;

    public IEnumerator MoveToPoint(Transform myObject, Vector2 point)
    {

        Vector2 positionDifference = point - (Vector2)myObject.position;

        
        //if (myObject.GetComponentInChildren<SpriteRenerer>() && positionDifference.x != 0)
            //(myObject.GetComponentInChildren<SpriteRenerer>().flipX = positionDifference.x > 0;
        
        while (positionDifference.magnitude > moveAccuracy)
        {

            myObject.Translate(moveSpeed * positionDifference.normalized * Time.deltaTime);
            positionDifference = point - (Vector2)myObject.position;
            yield return null;
        }

        myObject.position = point;

        //if (myObject == FindObjectOfType<ClickManager>().player || activeLocalScene == 0)
            //FindObjectOfType<ClickManager>().playerWalking = false;
        yield return null;
    }
}*/
