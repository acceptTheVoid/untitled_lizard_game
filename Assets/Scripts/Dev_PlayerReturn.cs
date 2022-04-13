using UnityEngine;

public class Dev_PlayerReturn : MonoBehaviour {
    private Vector3 _savedPos;
    private Transform _tr;
    
    private void Start() {
        _tr = GetComponent<Transform>();
        _savedPos = _tr.position;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.P)) {
            _savedPos = _tr.position;
        }
        
        if(Input.GetKey(KeyCode.R)) {
            _tr.position = _savedPos;
        }
    }
}
