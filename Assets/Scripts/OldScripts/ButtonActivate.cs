using UnityEngine;

public class ButtonActivate : Interactable {
    [SerializeField] private GameObject toActivate;

    private void Start() {
        toActivate.SetActive(false);
    }
    
    public override void Interact() {
        toActivate.SetActive(true);
    }
}
