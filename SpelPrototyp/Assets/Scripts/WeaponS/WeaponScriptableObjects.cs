using UnityEngine;

//Caspian

[CreateAssetMenu(menuName = "New Weapon")]

public class WeaponScriptableObjects : ScriptableObject
{
    public float Damage;
    public string WeaponName;
    public GameObject WeaponPrefab;
    
}
