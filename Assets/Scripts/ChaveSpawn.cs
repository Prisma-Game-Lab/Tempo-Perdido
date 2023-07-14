using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ChaveSpawn : ClickManager
{
    public float fallSpeed;
    public GameObject Chave;
    private bool falling = false;

    void Update()
    {
        if (falling)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
    }

    public void AtivarChave()
    {
        Chave.SetActive(true);
    }

    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        movementSO.initialPosition = Player.position;
        if (!interrupted)
        {
            falling = true;
        }
        interrupted = false;
    }

    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Floor"))
        {
            Chave.SetActive(true);
            Destroy(gameObject);
        }
    }
}
