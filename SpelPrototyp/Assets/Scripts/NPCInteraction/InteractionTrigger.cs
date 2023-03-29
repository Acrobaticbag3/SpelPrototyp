using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractionHandler;

public class InteractionTrigger : MonoBehaviour {
    // Start is called before the first frame update

    private bool isTriggeringNPC;
    [SerializeField] private GameObject triggerdNPC; 

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            isTriggeringNPC = true;
            
        }
    }

    void OnTriggerExit(Collider other) {
        
    }
}
