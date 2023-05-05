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
using System.Collections.Generic;
using System.Linq;

public class PlayerManager : MonoBehaviour
    
{
      
    private float maxHealth = 100;
    [SerializeField] public float currHealth;
    [SerializeField] private float currMaxHealth;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI healthText;
    public PlayerMagic magic;

    public List<Transform> respawnPoints;






    private void Awake() 
    {
        currHealth = maxHealth;
        var respawn = GameObject.Find("RespawnPoints");
        respawnPoints = respawn.GetComponentsInChildren<Transform>().ToList();
        respawnPoints.RemoveAt(0);
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

    private void Respawn()
    { 
        Vector3 closestPos = new Vector3(999999,999999,999999);  
        foreach (var points in respawnPoints)
        {
            if(Vector3.Distance(transform.position, points.position) <  Vector3.Distance(transform.position,closestPos)){
                closestPos = points.position;
            }
        } 
        transform.position = closestPos;

        currHealth = currMaxHealth;
    }


     private void Die()
    {
        Debug.Log("Ded");
        Respawn();
        //Particals
        //sound
        //whatever
    }
}
