/*  
    === === === === === === === === === === === ===

    This script was made by kevin.

    Here we have a script that handles all
    stamina related stuff. It also "somewhat"
    handles stamina requests from other
    scripts.

    === === === === === === === === === === === ===
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Movement;

public class PlayerStamina : MonoBehaviour {

    // Main stamina variables \\
    public float _currentStamina;
    public float _maxStamina = 400;
    private float _minStamina = 10.0f;
    public bool SuffitiantStamina => _currentStamina > _minStamina;

    // Stamina regen  \\
    private float staminaRegenAmount = 1f;
    private float regenTimerInSeconds = 3;

    // referenscase  \\
    private Movement movement;

    public enum Task {
        running,
        jumping,
        standing,
        attacking,
        // blocking,
    }

    private void Start(){
        movement = GetComponent<Movement>();
        // RectTransform rt;
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

            case Task.attacking:
                Attacking();
                break;
        }
    }

    private void Running() {
        if (_currentStamina > _minStamina) {
            _currentStamina = _currentStamina - 1; 
        }  
    }

    private void Jumping() {
        if (_currentStamina > _minStamina) {
            _currentStamina = _currentStamina - 30;
        }
    }

    private void Standing() {
        if (_currentStamina < _maxStamina) {
            Wait();
            _currentStamina = _currentStamina + staminaRegenAmount;
        }
    }

    private void Attacking() {
        if (_currentStamina > _minStamina) {
            _currentStamina = _currentStamina - 5;
        }
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(regenTimerInSeconds);
    }

}