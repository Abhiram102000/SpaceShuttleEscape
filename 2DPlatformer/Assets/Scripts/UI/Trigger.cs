using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<CollisionDialogueManagerTriggered>().StartDialogue();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
