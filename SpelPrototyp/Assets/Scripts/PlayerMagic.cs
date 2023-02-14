using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{

    [SerializeField] private Spells spellToCast;
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRegen = 5f;
    [SerializeField]private float manaRegenTimer;
    [SerializeField]private float timeBetweenManaRegren = 2f;
   

    private float timeBetweenCast = 0.5f;
    private float currentCastTimer;
    private bool castingMagic = false;

    [SerializeField] private Transform castPoint;


    private void Awake() 
    {
        currentMana = maxMana;
    }
    private void Update() 
    {
        bool hasMana = currentMana - spellToCast.SpellToCast.ManaCost >= 0f;
        currentCastTimer += Time.deltaTime;
        manaRegenTimer += Time.deltaTime;

        if(!castingMagic && Input.GetButtonDown("CastSpell") && hasMana)
        {     
            castingMagic = true;
            currentMana -= spellToCast.SpellToCast.ManaCost;
            CastSpell();
        }

        if(castingMagic)
        {    
            if(currentCastTimer > timeBetweenCast)
            {
                castingMagic = false;
            }
        }

        if(currentMana < maxMana)
        {
            if(manaRegenTimer > timeBetweenManaRegren)
            {
                currentMana += manaRegen * Time.deltaTime;
                currentMana = Mathf.Clamp(currentMana, 0, maxMana);
            }
        }
        
    }

    void CastSpell()
    {
        currentCastTimer = 0;
        manaRegenTimer = 0;
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
    }
    
}


