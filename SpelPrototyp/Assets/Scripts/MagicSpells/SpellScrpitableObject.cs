using UnityEngine;

    //Caspian
[CreateAssetMenu(menuName = "New Spell")]
public class SpellScrpitableObject : ScriptableObject
{   
    public float Damage;
    public float ManaCost;
    public float LifeTime;
    public float Speed;
    public float timeBetweenCast;
    
}
