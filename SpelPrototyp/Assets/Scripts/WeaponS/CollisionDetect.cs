using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{   
    public WeaponController wp;
    public WeaponScriptableObjects Weapon;
    public EnemyManager Enemy;
  private void OnTriggerEnter(Collider other) 
    {     
        
        if(other.gameObject.TryGetComponent<EnemyManager>(out EnemyManager enemyComponent) && wp.isAttacking == true)
        {
            enemyComponent.TakeDamage(Weapon.Damage);
        }
    }
}
