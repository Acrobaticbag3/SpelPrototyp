using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour {
    public TextMeshProUGUI nametext;
    public TextMeshProUGUI dialogueText;

    public bool isDoneInteracting = false;
    [SerializeField] private GameObject interactContainerDialouge;

    private Queue<string> sentences = new Queue<string>();

    // Start is called before the first frame update
    public void StartInteraction(Dialogue dialogue) {
        nametext.text = dialogueText.text;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }

        ContinueInteraction();
    }

    public void ContinueInteraction() {
        if (sentences.Count == 0) {
            EndDialogue();
            isDoneInteracting = true;
            interactContainerDialouge.SetActive(false);
            return;
        }
        isDoneInteracting = false;

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    private void EndDialogue() {
        Debug.Log("End Of Interaction");
    }
}
