//NOT IN USE 
//Caspian

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{   

    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }


    public void Run()
    {
        anim.Play("Running");
    }
    public void Walking()
    {
       anim.Play("Walking"); 
    }  
    public void Idle()
    {
        anim.Play("Idle");
    }
    public void Jumping()
    {
        anim.Play("Jumping");
    }
}   
         
