using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D _rb;
    private BoxCollider2D _bc;
    
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpVelocity = 5f;
    [SerializeField] private float sprintSpeed = 1.5f;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _bc = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var dir = new Vector2(x, y);

        if(Input.GetButtonDown("Jump") && IsGrounded()) {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift) && IsGrounded()) {
            dir *= sprintSpeed;
        }
        
        Walk(dir);
    }

    private void Walk(Vector2 dir) {
        _rb.velocity = new Vector2(dir.x * speed, _rb.velocity.y);
    }

    private void Jump() {
        _rb.velocity += Vector2.up * jumpVelocity;
    }

    private bool IsGrounded() {
        var bounds = _bc.bounds;
        var raycast = Physics2D.BoxCast(
            bounds.center, 
            bounds.size, 
            0f, 
            Vector2.down,
            .1f,
            platformsLayerMask
            );
        return raycast.collider != null;
    }
}
