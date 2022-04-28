using UnityEngine;

public class Animate : MonoBehaviour {
    [SerializeField] private Animator animator;
    private PlayerMovement _movementScript;
    private PlayerMovement.Direction _facing;

    private void Start() {
        _movementScript = GetComponent<PlayerMovement>();
        _facing = _movementScript.facing;
    }
    
    private void Update() {
        var newFacing = _movementScript.facing;
        if(_facing != newFacing) {
            
        }
    }
}
