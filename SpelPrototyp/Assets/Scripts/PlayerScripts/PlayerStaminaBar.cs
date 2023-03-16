using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerStamina;

public class PlayerStaminaBar : MonoBehaviour {

    // RawImage \\
    [SerializeField] private Transform rawImage;
    private float rawImageSize;
    PlayerStamina playerStamina ;

    // Start is called before the first frame update
    void Start() {        
        GameObject player = GameObject.Find("Player");
        playerStamina = player.GetComponent<PlayerStamina>();

    }

    // Update is called once per frame
    void Update() {
        float convertStaminaToBarSize = playerStamina._currentStamina / playerStamina._maxStamina;

        GetComponent<RectTransform>().sizeDelta =  new Vector2(200* convertStaminaToBarSize,50);
        
    }

}