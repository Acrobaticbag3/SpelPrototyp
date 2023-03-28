// Caspian 
using UnityEngine;

public class LevelSystem : MonoBehaviour {
    private int level;
    private int currExp;
    private int reqExp;

    [SerializeField] private GameObject LvlupMenu;

    private void Awake() {
        LvlupMenu.SetActive(false);
    }
    private void Start()
    {
        level = 0;
        currExp = 0;
        reqExp = 100;
    }

    public void GainExp(int amount)
    {
        currExp += amount;
        if (currExp >= reqExp)
        {
            LevelUp();
        }
    }
    
    private void Update() 
    {
        if(LvlupMenu.activeSelf)
        {
            Time.timeScale = 0.0f;
            GameManager.isPaused = true;
            Cursor.visible = true;
        }
        else if(!LvlupMenu.activeSelf)
        {
            Time.timeScale = 1.0f;
            Cursor.visible = false;
            GameManager.isPaused = false;
        }
    }
    public void LevelUp()
    {
        level++;
        currExp -= reqExp;
        LvlupMenu.SetActive(true);
        
    }   

    public void LvlAttack()
    {
        PlayerStats.DamageAmp += 0.1f;
        LvlupMenu.SetActive(false);      
    }
    public void LvlHealth()
    {
        PlayerStats.HealthAmp += 0.1f;
        LvlupMenu.SetActive(false);    
    }
    public void LvlArmor()
    {
        PlayerStats.Armor += 0.1f;
        LvlupMenu.SetActive(false);
    }
    public void LvlMana()
    {
        PlayerStats.ManaAmp += 0.1f;
        LvlupMenu.SetActive(false);
    }
    public void LvlStamina()
    {
        PlayerStats.StaminaAmp += 0.1f;
        LvlupMenu.SetActive(false);
    }
    
}

    

