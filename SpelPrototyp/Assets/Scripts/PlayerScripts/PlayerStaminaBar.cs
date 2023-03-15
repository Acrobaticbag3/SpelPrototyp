using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerStamina;

public class PlayerStaminaBar : MonoBehaviour {

    // RawImage \\
    [SerializeField] private Transform rawImage;
    private float rawImageSize;
    private float convertStaminaToBarSize;
    
    private float maxStamina;
    private float currentStamina;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

}