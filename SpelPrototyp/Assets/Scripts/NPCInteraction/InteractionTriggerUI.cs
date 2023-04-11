using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static InteractionTrigger;

public class InteractionTriggerUI : MonoBehaviour {
    [SerializeField] private GameObject interactContainer;
    [SerializeField] private InteractionTrigger interactionTrigger;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;

    private void Update() {
        if(interactionTrigger.GetInteractableObject() != null) {
            ShowText(interactionTrigger.GetInteractableObject());
        } else {
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
