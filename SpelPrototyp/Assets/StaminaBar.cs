using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour {
    private float currentStamina;
    private float minStamina = 0.0f;
    private float maxStamina = 100f;

    [SerializeField] private StaminaBar rawImage;
    private float staminaRegenAmount = 3.0f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
