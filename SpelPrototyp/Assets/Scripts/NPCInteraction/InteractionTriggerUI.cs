using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static InteractionTrigger;
using static DialogueManager;

public class InteractionTriggerUI : MonoBehaviour {
    [SerializeField] private GameObject interactContainer;
    [SerializeField] private InteractionTrigger interactionTrigger;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;
    private DialogueManager dialogueManager;

    void Start() {
        GameObject player = GameObject.Find("Player");
        dialogueManager = player.GetComponent<DialogueManager>();
    }

    private void Update() {
        if(interactionTrigger.GetInteractableObject() != null) {
            ShowText(interactionTrigger.GetInteractableObject());
        } else {
            HideText();
        }

      //  if(dialogueManager.isDoneInteracting == true) {
                
       // }
    } 

    private void ShowText(InteractableNPC interactableNPC) {
        interactContainer.SetActive(true);
        interactTextMeshProUGUI.text = interactableNPC.GetInteractionText();
    }

    private void HideText() {
        interactContainer.SetActive(false);
    }

    private void ShowTextDialogue(InteractableNPC interactableNPC) {
        interactContainer.SetActive(true);
        interactTextMeshProUGUI.text = interactableNPC.GetInteractionText();
    }

    private void HideTextDialouge() {
        interactContainer.SetActive(false);
    }
}
