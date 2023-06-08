using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : ClickManager
{
    [SerializeField] private JournalSO journal;
    [SerializeField] private string mailboxId;

    public override IEnumerator MoveToPoint(Vector2 point)
    {
        yield return base.MoveToPoint(point);
        journal.UnlockNewLetter(mailboxId);
    }
}
