using System;
using UnityEngine;

public class ButtonPress : MonoBehaviour {
    [SerializeField] private LayerMask playerLayer;
    
    void Update() {
        var collider = Physics2D.OverlapCircle(transform.position, 1, playerLayer);
        if (collider != null && Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Button was pressed");
        }
    }
}
