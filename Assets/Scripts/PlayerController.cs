using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpVelocity = 5f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        var dir = new Vector2(x, y);

        if (Input.GetButtonDown("Jump") && math.abs(_rb.velocity.y) < 0.1)
        {
            Jump();
        }
        
        Walk(dir);
    }

    private void Walk(Vector2 dir)
    {
        _rb.velocity = (new Vector2(dir.x * speed, _rb.velocity.y));
    }

    private void Jump()
    {
        _rb.velocity += Vector2.up * jumpVelocity;
    }
}
