using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Movement;

public class PlayerStamina : MonoBehaviour {

    // Main stamina variables \\
    public float _currentStamina;
    public float _maxStamina = 100f;
    private float minStamina = 10.0f;

    // Stamina regen  \\
    private float staminaRegenAmount = 3.0f;
    private float regenTimerInSeconds = 1.0f;

    // referenscase  \\
    private Movement movement;

    public enum Task {
        running,
        jumping,
        standing,
    }

    private void Start(){
        movement = GetComponent<Movement>();
        RectTransform rt;
    }

    private void Awake() {
        _currentStamina = _maxStamina;
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
        if (_currentStamina != minStamina) {
            _currentStamina = _currentStamina - 10; 
        }  
    }

    private void Jumping() {
        if (_currentStamina != minStamina) {
            _currentStamina = _currentStamina - 20;
        }
    }

    private void Standing() {
        if (_currentStamina != _maxStamina) {
            _currentStamina = _currentStamina + staminaRegenAmount;
        }
        Wait();
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(regenTimerInSeconds);
    }

}