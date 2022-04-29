using Unity.Profiling.LowLevel;
using UnityEngine;

public class InteractionController : MonoBehaviour {
    [SerializeField] private GameObject prompt;
    [SerializeField] private CapsuleCollider2D cc;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            CheckInteraction();
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    private void CheckInteraction() {
        var bounds = cc.bounds;
        // ReSharper disable once Unity.PreferNonAllocApi
        var hits = Physics2D.CapsuleCastAll(
            bounds.center,
            bounds.size,
            cc.direction,
            0f,
            Vector2.zero
        );

        if(hits.Length != 0) {
            foreach(var rc in hits) {
                if(rc.transform.CompareTag("Interactable")) {
                    rc.transform.GetComponent<Interactable>().Interact();
                }
            }
        }
    }

    public void ShowPrompt() {
        prompt.SetActive(true);
    }

    public void ClosePrompt() {
        prompt.SetActive(false);
    }
}
