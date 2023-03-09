using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    //Caspian
public class WeaponController : MonoBehaviour
{   
    
    [SerializeField]private bool CanAttack = false;
    [SerializeField]private float AttackCD;
    public bool isAttacking = false;
    Animator weaponAnimation;
   

    // Update is called once per frame
    void Update()
    {   
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
