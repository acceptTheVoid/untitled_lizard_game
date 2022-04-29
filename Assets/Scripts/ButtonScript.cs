using UnityEngine;

public class ButtonScript : Interactable {
    [SerializeField] private GameObject vine;

    private void Start() {
        vine.SetActive(false);
        interactionEnabled = true;
    }
    
    public override void Interact() {
        if(!interactionEnabled) return;
        
        vine.SetActive(true);
        interactionEnabled = false;
    }
}
