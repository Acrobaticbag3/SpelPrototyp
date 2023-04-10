// Caspian
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    //Caspian
public class EnemyManager : MonoBehaviour
{   
    public PlayerManager Player;
    public LevelSystem levelsystem;
    public EnemyScriptableObject Enemy;
    private float maxHealth;
   [SerializeField] private float currHealth;
   private Transform target;


    private void Awake() 
    {   
        maxHealth = Enemy.Health;
        currHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currHealth -= amount;

        if(currHealth <= 0)
        {
            Die();
        }
    }  

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Player.TakeDamage(Enemy.Damage / PlayerStats.Armor);
        }
    }
  

    

    private void Die()
    {
        Destroy(gameObject);
        levelsystem.GainExp(Enemy.exp);
        //Particals
        //sound
        //whatever
    }
}
