using System.Collections.Generic;
using UnityEngine;

public class DirectionChangeScript : MonoBehaviour {
    [SerializeField] private GameObject player;
    
    private PlayerMovement _movementScript;
    private List<(Transform, Vector3)> _playerChildren;

    private void Start() {
        _movementScript = player.GetComponent<PlayerMovement>();
        _playerChildren = new List<(Transform, Vector3)>();
        
        var children = player.transform.childCount;
        for(var i = 0; i != children; ++i) {
            var child = player.transform.GetChild(i);
            var startPos = child.transform.localPosition;
            _playerChildren.Add((child, startPos));
        }
    }

    private void Update() {
        var facing = _movementScript.facing;
        foreach(var i in _playerChildren) {
            i.Item1.localPosition = i.Item2 * facing switch {
                PlayerMovement.Direction.Left => -1,
                _ => 1
            };
        }
    }
}
