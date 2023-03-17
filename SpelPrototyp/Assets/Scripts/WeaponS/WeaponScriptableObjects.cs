/*  
    === === === === === === === === === === === ===

    This script was writen by Caspian

    A collection of scriptable objects

    === === === === === === === === === === === ===
*/

using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]

public class WeaponScriptableObjects : ScriptableObject
{
    public float Damage;
    public string WeaponName;
    public GameObject WeaponPrefab;
    
}
