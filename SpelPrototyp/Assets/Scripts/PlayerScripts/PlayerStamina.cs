using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Movement;

public class PlayerStamina : MonoBehaviour {
    
    [SerializeField] private float currentStamina;
    private float minStamina = 10.0f;
    private float maxStamina = 100f;

    private float staminaRegenAmount = 3.0f;
    private float regenTimerInSeconds = 1.0f;
    private Movement movement;

    public enum Task {
        running,
        jumping,
        standing,
    }

    private void Start(){
        movement = GetComponent<Movement>();
    }

    private void Awake() {
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    private void Update() {
        switch (movement.Task) {
            case Task.running:
                Running();
                break;

            case Task.jumping:
                Jumping();
                break;

            case Task.standing:
                Standing();
                break;
            
            default:
                Standing();
                break;
        }
    }

    private void Running() {
        if (currentStamina != minStamina) {
            currentStamina = currentStamina - 10; 
        }  
    }

    private void Jumping() {
        if (currentStamina != minStamina) {
            currentStamina = currentStamina - 20;
        }
    }

    private void Standing() {
        currentStamina = currentStamina + staminaRegenAmount;
        Wait();
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(regenTimerInSeconds);
    }

}