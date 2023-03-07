using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

    //Caspian
public class PlayerManager : MonoBehaviour
    
{
    LevelSystem level = new LevelSystem();
    private float maxHealth = 100;
   [SerializeField] private float currHealth;
   [SerializeField] private Slider healthBar;


    private void Awake() 
    {
        currHealth = maxHealth;
    }
    private void Update() 
    {
        healthBar.value = currHealth;    
    }
    
    public void TakeDamage(float amount)
    {
        currHealth -= amount ;

        if(currHealth <= 0)
        {
            Die();
        }
    }


     private void Die()
    {
        Debug.Log("Ded");
        //Particals
        //sound
        //whatever
    }
}
