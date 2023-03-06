using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMagic : MonoBehaviour
{
    [SerializeField] private Spells spellToCast; //Detta är spellen som castas detta ska vara samma sak som den activa spellen i spells listan 
    private float maxMana = 100f;
    private float currentMana;
    private float manaRegen = 7.5f;
    private float manaRegenTimer;
    private float timeBetweenManaRegren = 2f;

    [SerializeField] private Slider manaBar;

    private float currentCastTimer;
    private bool castingMagic = false;

    [SerializeField] private Transform castPoint;

    public List<Spells> spellList = new List<Spells>();

    [SerializeField] private GameObject SpellCircle;
    [SerializeField] private Button MagicMissileButton;
    [SerializeField] private Button FireBallButton;


    private void Awake()
    {
        
        currentMana = maxMana;
        SpellCircle.SetActive(false);

        Button Missile = MagicMissileButton.GetComponent<Button>();
        Button Fire = FireBallButton.GetComponent<Button>();
    }

    private void Update()
    {
        bool hasMana = currentMana - spellToCast.SpellToCast.ManaCost >= 0f;
        currentCastTimer += Time.deltaTime;
        manaRegenTimer += Time.deltaTime;
        manaBar.value = currentMana;

         if (Input.GetKeyDown(KeyCode.H))
        {      
            if (GameManager.swtichingSpells == true)
                {
                    StopSwitchSpell();
                }
                else
                {
                    SwitchSpell();
                }
        }
        // Everything after this code stops when paused 
        // if code wants to be run even if pasued put before
        if (GameManager.isPaused || GameManager.swtichingSpells)
        {
            return;
        }

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

       
    }
    private void SwitchSpell()
    {
        SpellCircle.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        GameManager.swtichingSpells = true;
        /*
        spellToCast = spellList[0];
        */
    }
    private void StopSwitchSpell()
    {
        SpellCircle.SetActive(false);
        Time.timeScale = 1; 
        Cursor.visible = false;
        GameManager.swtichingSpells = false;
    }

    public void FireBallClicked()
    {
        spellToCast = spellList[0];  
    }
    public void MagicMissileClicked()
    {
        spellToCast = spellList[1];  
    }

    private void CastSpell()
    {
        currentCastTimer = 0;
        manaRegenTimer = 0;
        Instantiate(spellToCast, castPoint.position, castPoint.rotation);
    }

}


