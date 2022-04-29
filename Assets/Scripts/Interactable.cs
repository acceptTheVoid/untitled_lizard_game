using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour {
    public abstract void Interact();

    private void Reset() {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Debug.Log("Player entered");
            other.GetComponent<InteractionController>().ShowPrompt();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            Debug.Log("Player exited");
            other.GetComponent<InteractionController>().ClosePrompt();
        }
    }
}
