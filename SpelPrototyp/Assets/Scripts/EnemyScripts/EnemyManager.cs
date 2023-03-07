using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    //Caspian
public class EnemyManager : MonoBehaviour
{   
    public PlayerManager Player;
    public EnemyScriptableObject Enemy;
    private float maxHealth;
   [SerializeField] private float currHealth;


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
            Player.TakeDamage(Enemy.Damage);
        }
    }
  

    

    private void Die()
    {
        Destroy(gameObject);
        //Particals
        //sound
        //whatever
    }
}
