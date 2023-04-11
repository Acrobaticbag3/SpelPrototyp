using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : MonoBehaviour {
    public Dialogue dialogue;

    [SerializeField] private string interactionText;

    private static DialogueManager _dialogueManager;

    public void Interact() {
        GetDialogueManager().StartInteraction(dialogue);
    }

    public string GetInteractionText() {
        return interactionText;
    }

    private DialogueManager GetDialogueManager() {  // Singleton Pattern
        if (_dialogueManager == null) {
            _dialogueManager = FindObjectOfType<DialogueManager>();
            if (_dialogueManager == null) {
                Debug.LogError("Unable to find DialogueManager");
            }
        }
        return _dialogueManager;
    }
}
