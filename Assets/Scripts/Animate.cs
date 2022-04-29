using UnityEngine;

public class Animate : MonoBehaviour {
    [SerializeField] private Animator animator;
    private PlayerMovement _movementScript;
    private ItemController _itemController;

    private void Start() {
        _movementScript = GetComponent<PlayerMovement>();
        _itemController = GetComponent<ItemController>();
    }

    private void Update() {
        
    }
}
