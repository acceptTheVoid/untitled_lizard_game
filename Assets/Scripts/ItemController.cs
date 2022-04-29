using System;
using UnityEngine;

public class ItemController : MonoBehaviour {
    public bool isEquipped;
    public GameObject item;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject ебучийПосохВРуках;

    private void Start() {
        var isItemPresent = item != null;
        
        if(isEquipped && isItemPresent) {
            item.SetActive(false);
        } else if(isEquipped) {
            throw new Exception("Player must have an item assigned");
        } else if(isItemPresent) {
            Equip(item);
        }

        if(!isEquipped && !isItemPresent) {
            ебучийПосохВРуках.SetActive(false);
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Q)) {
            Throw();
        }
    }
    
    public void Equip(GameObject itemToEquip) {
        if(isEquipped) return;
        
        item = itemToEquip;
        isEquipped = true;
        item.transform.SetParent(ебучийПосохВРуках.transform);
        item.SetActive(false);
        ебучийПосохВРуках.SetActive(true);
    }

    public void Throw() {
        item.transform.position = ебучийПосохВРуках.transform.position;
        var scale = item.transform.localScale;
        scale.x = Math.Abs(scale.x * playerMovement.facing switch {
            PlayerMovement.Direction.Left => -1,
            _ => 1
        });
        item.transform.localScale = scale;
        
        item.transform.SetParent(null);
        item.SetActive(true);
        ебучийПосохВРуках.SetActive(false);
        isEquipped = false;
        item = null;
    }
}
