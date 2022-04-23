using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D _rb;
    private CapsuleCollider2D _cc;

    [SerializeField] private GameObject prompt;
    [SerializeField] private LayerMask platformsLayerMask;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpVelocity = 5f;
    [SerializeField] private float sprintSpeed = 1.5f;
    [SerializeField] private float stickForce = 0.5f;

    public bool handsBusy;

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _cc = GetComponent<CapsuleCollider2D>();
    }

    private void Update() {
        var x = Input.GetAxis("Horizontal");
        var dir = new Vector2(x, 0);

        if(Input.GetButtonDown("Jump")) {
            Jump();
        }

        if(Input.GetKey(KeyCode.LeftShift) && TypeOfGround() != 0) {
            dir.x *= sprintSpeed;
        }
        
        if(Input.GetKeyDown(KeyCode.E)) CheckInteraction();

        Walk(dir);
    }

    private void Walk(Vector2 dir) {
        _rb.velocity = new Vector2(dir.x * speed, _rb.velocity.y);
    }

    private void Jump() {
        _rb.velocity += Vector2.up * (jumpVelocity * TypeOfGround());
    }

    private float TypeOfGround() {
        var bounds = _cc.bounds;
        var raycast = Physics2D.CapsuleCast(
            bounds.center, 
            bounds.size, 
            _cc.direction,
            0f,
            Vector2.down,
            .1f,
            platformsLayerMask
            );

        if(raycast.collider == null) return 0;

        var type = raycast.transform.CompareTag("StickyPlatform");
        return type ? stickForce : 1;
    }

    public void ShowPrompt() {
        prompt.SetActive(true);
    }

    public void ClosePrompt() {
        prompt.SetActive(false);
    }

    private void CheckInteraction() {
        var bounds = _cc.bounds;
        var hits = Physics2D.CapsuleCastAll(
            bounds.center,
            bounds.size,
            _cc.direction,
            0f,
            Vector2.zero
        );

        if(hits.Length != 0) {
            foreach (var rc in hits) {
                if (rc.transform.CompareTag("Interactable")) {
                    rc.transform.GetComponent<Interactable>().Interact();
                }
            }
        }
    }
}
