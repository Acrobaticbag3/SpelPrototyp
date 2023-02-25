using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName  = "New Spell", menuName = "Spells")]
public class SpellScrpitableObject : ScriptableObject
{   
    public float Damage;
    public float ManaCost;
    public float LifeTime;
    public float Speed;
    public float timeBetweenCast;
    
}
