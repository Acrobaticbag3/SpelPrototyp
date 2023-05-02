using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDoor : MonoBehaviour
{
    public GameObject door;
    public DialogueManager dialog;



        private void Start() {
            dialog = GameObject.FindGameObjectWithTag("Player").GetComponent<DialogueManager>();
        }
    private void Update() {
        if(dialog.isDoneInteracting == true)
        {
            door.SetActive(false);
        }
    }
}
