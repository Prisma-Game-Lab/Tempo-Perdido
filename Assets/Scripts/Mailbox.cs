using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mailbox : ClickManager
{
    [SerializeField] private JournalSO journal;
    [SerializeField] private string mailboxId;

    public override void Interact()
    {
        base.Interact();
        journal.UnlockNewLetter(mailboxId);
    }
}
