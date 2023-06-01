using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public float cameraMoveSpeed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.gameObject.name == "SetaEsquerda")
                {
                    MoveCameraLeft();
                }
                else if (hit.collider.gameObject.name == "SetaDireita")
                {
                    MoveCameraRight();
                }
            }
        }
    }

    private void MoveCameraLeft()
    {
        cameraFollow.cameraLocked = false;
        StartCoroutine(MoveCameraCoroutine(Vector3.left));
    }

    private void MoveCameraRight()
    {
        cameraFollow.cameraLocked = false;
        StartCoroutine(MoveCameraCoroutine(Vector3.right));
    }

    private IEnumerator MoveCameraCoroutine(Vector3 direction)
    {
        Vector3 targetPosition = cameraFollow.transform.position + direction;

        while (Vector3.Distance(cameraFollow.transform.position, targetPosition) > 0.01f)
        {
            cameraFollow.transform.position = Vector3.Lerp(cameraFollow.transform.position, targetPosition, cameraMoveSpeed * Time.deltaTime);
            yield return null;
        }

        cameraFollow.enabled = true;
    }
}

