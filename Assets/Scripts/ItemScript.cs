using UnityEngine;

public class ItemScript : Interactable {
    [SerializeField] private ItemController itemController;
    [SerializeField] private GameObject thisGameObject;
    
    public override void Interact() {
        itemController.Equip(thisGameObject);
    }
}
