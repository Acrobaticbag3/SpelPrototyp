using UnityEngine;

[CreateAssetMenu(menuName = "New Enemy")]

 //Caspian
public class EnemyScriptableObject : ScriptableObject 
{
    public float Health;
    public float Damage;
    public float AttackRange;
    public float AggroRange;
    public float Speed;
    public int exp;
}

    
