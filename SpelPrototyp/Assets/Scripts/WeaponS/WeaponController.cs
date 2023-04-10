/*  
    === === === === === === === === === === === ===

    This script was writen by Caspian

    The objective of this script is to handle the
    players weapons.

    === === === === === === === === === === === ===
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerStamina;

public class WeaponController : MonoBehaviour
{   
    
    [SerializeField]private bool CanAttack = false;
    [SerializeField]private float AttackCD;
    public bool isAttacking = false;
    Animator weaponAnimation;

    // References \\ 
    private Task task;
    public Task Task => task;
   

    // Update is called once per frame
    void Update()
    {   
        // Everything after this code stops when paused 
        // if code wants to be run even if pasued put before
        if (GameManager.isPaused || GameManager.swtichingSpells) {
            return;
        } 
        AttackCD += Time.deltaTime;


        if(CanAttack == true)
        {
            isAttacking = false;
        }

        if(AttackCD >= 1)
        {
            CanAttack = true;
        }

        if(Input.GetButton("SwordAttack") && CanAttack)
        {   
            task = PlayerStamina.Task.attacking;
            SwordAttack();
        }
    }


    public void SwordAttack()
    {
        if(weaponAnimation == null) weaponAnimation = GetComponentInChildren<Animator>();
        CanAttack = false;
        weaponAnimation.SetTrigger("Attack");
        isAttacking = true;
        //anim.SetTrigger("Attack");
        AttackCD = 0f;
    }


    
}
