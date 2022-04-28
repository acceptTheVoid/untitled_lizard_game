using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    public enum Direction {
        Left,
        Right
    }

    public Direction facing = Direction.Right;
    
    [SerializeField] private float speed = 15;
    [SerializeField] private float jumpSpeed = 15;
    [SerializeField] private float sprintSpeed = 1.5f;
    [SerializeField] private float stickiness = 0.5f;
    [SerializeField] private LayerMask platformLayer;
    
    private Rigidbody2D _rb;
    private CapsuleCollider2D _cc;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _cc = GetComponent<CapsuleCollider2D>();
    }
    
    private void Update() {
        Walk();
        Jump();
    }

    private void Walk() {
        var input = Input.GetAxis("Horizontal");
        facing = input == 0 ? facing : 
            input < 0 ? Direction.Left : Direction.Right;
        _rb.velocity = new Vector2(input * speed * Sprint(), _rb.velocity.y);
    }

    private void Jump() {
        if(Input.GetButtonDown("Jump")) {
            _rb.velocity += Vector2.up * (jumpSpeed * GroundType());
        }
    }

    private float Sprint() {
        var resultSpeed = 1f;
        if(Input.GetKey(KeyCode.LeftShift) && GroundType() != 0) {
            resultSpeed *= sprintSpeed;
        }
        
        return resultSpeed;
    }

    private float GroundType() {
        var bounds = _cc.bounds;
        var ground = Physics2D.CapsuleCast(
            bounds.center,
            bounds.size,
            _cc.direction,
            0f,
            Vector2.down,
            .1f,
            platformLayer
        );

        // ReSharper disable once Unity.PerformanceCriticalCodeNullComparison
        if(ground.collider == null) return 0;

        var type = ground.transform.CompareTag("StickyPlatform");
        
        if(type) return stickiness;
        return 1;
    }
}
