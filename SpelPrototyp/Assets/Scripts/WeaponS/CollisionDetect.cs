using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{   
    public WeaponScriptableObjects Weapon;
    public EnemyManager Enemy;
  private void OnTriggerEnter(Collider other) 
    {     
        
        if(other.gameObject.tag == "Enemy")
        {
            Enemy.TakeDamage(Weapon.Damage);
            Debug.Log("Enemy ihy");
        }
    }
}
