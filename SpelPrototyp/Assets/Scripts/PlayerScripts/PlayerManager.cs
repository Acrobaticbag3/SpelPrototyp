/*  
    === === === === === === === === === === === ===

    This script was writen by Caspian. 

    It handles the player and some possible 
    requests made by the player.

    === === === === === === === === === === === ===
*/

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
    
{
    LevelSystem level;
 
    private float maxHealth = 100;
   [SerializeField] private float currHealth;
   [SerializeField] private float currMaxHealth;
   [SerializeField] private Slider healthBar;
   [SerializeField] private TextMeshProUGUI healthText;



    private void Awake() 
    {
        currHealth = maxHealth;
        level = gameObject.AddComponent<LevelSystem>();
    }
    private void Update() 
    {
        healthBar.value = currHealth;  
        currMaxHealth = maxHealth * PlayerStats.HealthAmp;  
        healthBar.maxValue = currMaxHealth;
        healthText.text = healthBar.value.ToString();
    }
    
    public void TakeDamage(float amount)
    {
        currHealth -= amount;

        if(currHealth <= 0)
        {
            Die();
        }
    }


     private void Die()
    {
        Debug.Log("Ded");
        //Particals
        //sound
        //whatever
    }
}
