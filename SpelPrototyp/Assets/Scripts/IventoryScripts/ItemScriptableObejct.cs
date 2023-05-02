using UnityEngine;


    //Caspian
[CreateAssetMenu(menuName = "New Item")]
public class ItemScriptableObejct : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite icon;

    public int value;
}
