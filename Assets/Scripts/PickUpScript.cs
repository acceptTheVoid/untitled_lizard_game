using UnityEngine;

public class PickUpScript : MonoBehaviour {
    [SerializeField] private GameObject player;
    [SerializeField] private Transform container;

    private Rigidbody2D _rb;
    private PlayerController _pc;
    private BoxCollider2D _bc;

    public float pickUpRange;
    
    public bool equipped;

    private void Start() {
        _pc = player.GetComponent<PlayerController>();
        _rb = GetComponent<Rigidbody2D>();
        _bc = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        Vector2 distanceToPlayer = player.transform.position - transform.position;
        if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !_pc.handsBusy) {
            PickUp();
        }        
        
        if(equipped && Input.GetKeyDown(KeyCode.Q)) {
            Drop();
        }
    }

    private void PickUp() {
        equipped = true;
        _pc.handsBusy = true;

        transform.SetParent(container);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);

        _rb.isKinematic = true;
        _bc.isTrigger = true;
    }

    private void Drop() {
        equipped = false;
        _pc.handsBusy = false;

        transform.SetParent(null);
        
        _rb.isKinematic = false;
        _bc.isTrigger = false;

        _rb.velocity = player.GetComponent<Rigidbody2D>().velocity;
    }
}
