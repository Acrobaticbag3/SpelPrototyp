using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagic : MonoBehaviour
{
    [SerializeField] private Spells spellToCast; //Detta är spellen som castas detta ska vara samma sak som den activa spellen i spells listan 
    private float maxMana = 100f;
    private float currentMana;
    private float manaRegen = 5f;
    private float manaRegenTimer;
    private float timeBetweenManaRegren = 2f;

    private float currentCastTimer;
    private bool castingMagic = false;

    [SerializeField] private Transform castPoint;

    public List<Spells> spellList = new List<Spells>();

    [SerializeField] private GameObject SpellCircle;
    private bool swtichingSpells = false;

    private void Awake()
    {
        currentMana = maxMana;
        SpellCircle.SetActive(false);
    }
    private void Update()
    {
        bool hasMana = currentMana - spellToCast.SpellToCast.ManaCost >= 0f;
        currentCastTimer += Time.deltaTime;
        manaRegenTimer += Time.deltaTime;

        if (!castingMagic && Input.GetButton("CastSpell") && hasMana)
        {
            castingMagic = true;
            currentMana -= spellToCast.SpellToCast.ManaCost;
            CastSpell();
        }

        if (castingMagic)
        {
            if (currentCastTimer > spellToCast.SpellToCast.timeBetweenCast)
            {
                castingMagic = false;
            }
        }

        if (currentMana < maxMana)
        {
            if (manaRegenTimer > timeBetweenManaRegren)
            {
                currentMana += manaRegen * Time.deltaTime;
                currentMana = Mathf.Clamp(currentMana, 0, maxMana);
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (swtichingSpells == true)
            {
                StopSwitchSpell();
            }
            else
            {
                SwitchSpell();
            }
        }
    }

    private void SwitchSpell()
    {
        SpellCircle.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        swtichingSpells = true;
        /*
        spellToCast = spellList[0];
        */
    }
    private void StopSwitchSpell()
    {
        SpellCircle.SetActive(false);
        Time.timeScale = 1; //bug when jumping, bulids momentum when paused
        Cursor.visible = false;
        swtichingSpells = false;
    }

    private void CastSpell()
    {
        currentCastTimer = 0;
        manaRegenTimer = 0;
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
    }

}


