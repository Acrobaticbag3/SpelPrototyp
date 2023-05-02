/*  
    === === === === === === === === === === === ===

    This script was writen by Caspian. 

    It handles the player and some possible 
    requests made by the player.

    === === === === === === === === === === === ===
*/

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
    
{
      
    private float maxHealth = 100;
    [SerializeField] public float currHealth;
    [SerializeField] private float currMaxHealth;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    public PlayerMagic magic;



    private void Awake() 
    {
        currHealth = maxHealth;
    }
    private void Update() 
    {
        healthBar.value = currHealth;  
        currMaxHealth = maxHealth * PlayerStats.HealthAmp;  
        healthBar.maxValue = currMaxHealth;
        healthText.text = healthBar.value.ToString();
        Cursor.visible = true;
    }
    
    public void TakeDamage(float amount)
    {
        currHealth -= amount;

        if(currHealth <= 0)
        {
            Die();
        }
    }

    public void HealPlayer(float amount)
    {
        currHealth += amount;
    }
    public void ManaPot(float amount)
    {
        magic.currentMana += amount;
    }


     private void Die()
    {
        Debug.Log("Ded");
        //Particals
        //sound
        //whatever
    }
}
