using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataFloor : MonoBehaviour
{
    public Transform goToPoint;
    public float heigh = 1f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            worldPosition.z = goToPoint.position.z + heigh;
            goToPoint.position = worldPosition;
        }
    }
}

