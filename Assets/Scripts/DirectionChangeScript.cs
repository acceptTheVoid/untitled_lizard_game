using System.Collections.Generic;
using UnityEngine;

public class DirectionChangeScript : MonoBehaviour {
    [SerializeField] private GameObject player;
    
    private PlayerMovement _movementScript;
    private List<Vector3> _childrenTransforms;
    [SerializeField] private List<Transform> playerChildren;

    private void Start() {
        _movementScript = player.GetComponent<PlayerMovement>();
        _childrenTransforms = new List<Vector3>();

        foreach(var it in playerChildren) {
            _childrenTransforms.Add(it.transform.localPosition);
        }
    }

    private void Update() {
        var facing = _movementScript.facing;
        for(var i = 0; i != playerChildren.Count; ++i) {
            var posMultiplier = facing switch {
                PlayerMovement.Direction.Left => -1,
                _ => 1
            };
            var newVec = new Vector3(_childrenTransforms[i].x * posMultiplier, _childrenTransforms[i].y);
            
            playerChildren[i].localPosition = newVec;
        }
    }
}
