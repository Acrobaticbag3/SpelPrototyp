//Caspian
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brioch : MonoBehaviour
{
    public DialogueManager dialog;
    [SerializeField] private GameObject door;


    private void Start() {
        dialog = GameObject.FindGameObjectWithTag("Player").GetComponent<DialogueManager>();
    }


    private void Update() {
      if(dialog.isDoneInteracting == true)
      {
        gameObject.SetActive(false);
        door.transform.Rotate(0, 89, 0, Space.Self);
      }    
    } 
  
}
 