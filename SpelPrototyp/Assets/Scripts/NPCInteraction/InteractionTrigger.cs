using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractionTriggerUI;

public class InteractionTrigger : MonoBehaviour { 

    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject Iconussy;
    [SerializeField] private GameObject interactContainer;
    [SerializeField] private GameObject interactContainerDialouge;
    public bool isPressed = false;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            isPressed = true;
            float interactionRange = 2f;
            Collider[] colliderArr = Physics.OverlapSphere(transform.position, interactionRange);
            foreach (Collider collider in colliderArr) {
                if(collider.TryGetComponent(out InteractableNPC interactableNPC)) {
                    interactContainerDialouge.SetActive(true);
                    interactContainer.SetActive(false);
                    interactableNPC.Interact();
                }
            }
        } else {
            isPressed = false;
        }
    }

    public InteractableNPC GetInteractableObject() {
        List<InteractableNPC> interactableNPCList = new List<InteractableNPC>();
        float interactionRange = 2f;
        Collider[] colliderArr = Physics.OverlapSphere(transform.position, interactionRange);
        foreach (Collider collider in colliderArr) {
            if(collider.TryGetComponent(out InteractableNPC interactableNPC)) {
                interactableNPCList.Add(interactableNPC);
            }
        }

        InteractableNPC closestinteractableNPC = null;
        foreach(InteractableNPC interactableNPC in interactableNPCList) {
            if(closestinteractableNPC == null) {
                closestinteractableNPC = interactableNPC;
            } else if(Vector3.Distance(transform.position, interactableNPC.transform.position) < Vector3.Distance(transform.position, closestinteractableNPC.transform.position)) {
                closestinteractableNPC = interactableNPC;
            }
        } 
        return closestinteractableNPC;
    }
}
