using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static InteractionTrigger;
using static DialogueManager;

public class InteractionTriggerUI : MonoBehaviour {
    [SerializeField] private GameObject interactContainer;
    [SerializeField] private GameObject interactContainerDialouge;
    [SerializeField] private InteractionTrigger interactionTrigger;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;
    private DialogueManager dialogueManager;

    void Start() {
        GameObject player = GameObject.Find("Player");
        dialogueManager = player.GetComponent<DialogueManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "NPC" && interactionTrigger.isPressed == false) {
            ShowText(interactionTrigger.GetInteractableObject());
        } 
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "NPC") {
            interactContainerDialouge.SetActive(false);
            HideText();
        }
    }

    private void ShowText(InteractableNPC interactableNPC) {
        interactContainer.SetActive(true);
        interactTextMeshProUGUI.text = interactableNPC.GetInteractionText();
    }

    private void HideText() {
        interactContainer.SetActive(false);
    }
}
