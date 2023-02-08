using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{

    [SerializeField] private Spells SpellToCast;
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRegen = 5f;
    [SerializeField] private float timeBetweenCast = 2f;
    private float currentCastTimer;

    private bool castingMagic = false;

    [SerializeField] private Transform castPoint;


    private void Update() 
    {
        if(!castingMagic && Input.GetButtonDown("CastSpell"))
        {
            Debug.Log("D");
            castingMagic = true;
            currentCastTimer = 0f;
            CastSpell();
        }

        if(castingMagic)
        {
            currentCastTimer += Time.deltaTime;

            if(currentCastTimer > timeBetweenCast)
            {
                castingMagic = false;
            } 
        }
    }

    void CastSpell()
    {
        Instantiate(SpellToCast, castPoint.position, castPoint.rotation);
    }
}


