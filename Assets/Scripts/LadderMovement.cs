using UnityEngine;

public class LadderMovement : MonoBehaviour {
    [SerializeField] private float speed = 8f;
    private float _vertical;
    private bool _isLadder;
    private bool _isClimbing;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject Player;

    private void Update() {
        _vertical = Input.GetAxis("Vertical");

        if (_isLadder && Mathf.Abs(_vertical) > 0f) {
            _isClimbing = true;
        }
    }

    private void FixedUpdate() {
        if (_isClimbing) {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, _vertical * speed);
        } else {
            rb.gravityScale = 3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ladder") && !Player.GetComponent<PlayerController>().handsBusy) {
            _isLadder = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Ladder") && !Player.GetComponent<PlayerController>().handsBusy) {
            _isLadder = false;
            _isClimbing = false;
        }
    }
}
