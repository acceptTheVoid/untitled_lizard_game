using UnityEngine;

public class BetterJump : MonoBehaviour {
    private Rigidbody2D _rb;
    [SerializeField] private float fallMultiplier = 10f;
    [SerializeField] private float lowJumpMultiplayer = 5f;
    
    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (_rb.velocity.y < 0) {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (_rb.velocity.y > 0 && !Input.GetButton("Jump")) {
            _rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer - 1) * Time.deltaTime;
        }
    }
}
